using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float mouseSensitivity;
    [SerializeField] float rollSensitivity;
    [SerializeField] float playerSpeed;
    Rigidbody rb;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        //playerSpeed = 60;
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
        transform.Rotate(mouseSensitivity * Input.GetAxis("Mouse Y") * Time.deltaTime, mouseSensitivity * Input.GetAxis("Mouse X") * 0.75f * Time.deltaTime, -Input.GetAxis("Roll") * rollSensitivity * Time.deltaTime);

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
        rb.AddForce(transform.forward * Time.deltaTime * playerSpeed * Input.GetAxis("Vertical"), ForceMode.Acceleration);
        rb.AddForce(transform.up * Time.deltaTime * playerSpeed * 0.9f * Input.GetAxis("Height"), ForceMode.Acceleration);
        rb.AddForce(transform.right * Time.deltaTime * playerSpeed * 0.8f * Input.GetAxis("Horizontal"), ForceMode.Acceleration);

        //This will make drag bigger to make it a little less floaty
        if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0 && Input.GetAxis("Height") == 0)
        {
            rb.drag = 2;
        }
        else
        {
            rb.drag = 0;
        }
    }

    //This is to make sure the player stays in the body and can accelerate to fun speeds
    private void OnTriggerEnter(Collider other)
    {        
        if(other.tag == "SpeedLimit")
        {
            playerSpeed = 500;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "SpeedLimit")
        {
            playerSpeed = 300;
        }
    }
}
