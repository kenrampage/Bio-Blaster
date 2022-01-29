using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketScript : MonoBehaviour
{
    [SerializeField] float rocketSpeed;
    Rigidbody rb;
    bool hitSumn;
    bool playedExplosion;
    ParticleSystem explosion;

    // Start is called before the first frame update
    void Start()
    {
        hitSumn = false;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Rocket movement
        rb.AddForce(-transform.forward * rocketSpeed, ForceMode.Acceleration);

        //Make sure an explosion gets played and the rocket gets deleted.
        if (hitSumn)
        {
            //EXPLODE AND DESTROY
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        hitSumn = true;
    }
}
