using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RocketScript : MonoBehaviour
{
    [SerializeField] float rocketSpeed;
    Rigidbody rb;
    bool hitSumn;
    bool playedExplosion;
    [SerializeField] ParticleSystem explosion;
    [SerializeField] float damage;
    [SerializeField] private GameObject explosionSoundPrefab;

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
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 3f);
        foreach (Collider hitCollider in hitColliders)
        {
            if (hitCollider.gameObject.tag == "Enemy")
            {
                hitCollider.gameObject.GetComponent<EnemyHealth>().health -= damage;
                Instantiate(explosion, transform.position, Quaternion.identity);
                Instantiate(explosionSoundPrefab,transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Instantiate(explosionSoundPrefab,transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
