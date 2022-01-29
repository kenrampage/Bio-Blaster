using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float mouseSensitivity;
    [SerializeField] float rollSensitivity;
    [SerializeField] float playerSpeed;

    void Start()
    {
        playerSpeed = 20;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void FixedUpdate()
    {
        //Any custom axis can be changed in Edit > Project Settings > Input Manager > Axes

        //This will make sure the cursor can always be locked to the screen again, if the player 
        //has got the cursor in another lockState.
        if(Cursor.lockState != CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        //This makes the turn the ship left to right, multiplied by sensitivity
        transform.Rotate(-mouseSensitivity * Input.GetAxis("Mouse Y") * Time.deltaTime, mouseSensitivity * Input.GetAxis("Mouse X") * Time.deltaTime, -Input.GetAxis("Roll") * rollSensitivity * Time.deltaTime);

        //This will increase the amount of roll te longer you roll, to give a more dynamic feel
        if (Input.GetAxis("Roll") != 0)
        {
            if (rollSensitivity < 350)
            {
                rollSensitivity += 75 / rollSensitivity;
            }
        }
        //In case the player stops rolling, it automatically resets to 100
        else if(Input.GetAxis("Roll") == 0)
        {
            rollSensitivity = 100;
        }

        //This will make the player move in all directions
        transform.Translate(playerSpeed * .75f * Input.GetAxis("Horizontal") * Time.deltaTime, Input.GetAxis("Height") * Time.deltaTime * playerSpeed * .85f, playerSpeed * Time.deltaTime * Input.GetAxis("Vertical"));
    }

    //This is to make sure the player stays in the body and can accelerate to fun speeds
    private void OnTriggerEnter(Collider other)
    {        
        if(other.tag == "SpeedLimit")
        {
            playerSpeed = 17;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "SpeedLimit")
        {
            playerSpeed = 7;
        }
    }
}
