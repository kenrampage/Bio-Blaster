using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    [SerializeField] float speed;
    float timeBeforeDeath;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        timeBeforeDeath = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(transform.forward * speed, ForceMode.Impulse);
        //gameObject.transform.Translate(-transform.forward * Time.deltaTime * speed);
        timeBeforeDeath -= Time.deltaTime;
        if(timeBeforeDeath < 0)
        {
            Destroy(gameObject);
        }
        
    }
}
