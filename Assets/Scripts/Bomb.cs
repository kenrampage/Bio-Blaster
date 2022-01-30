using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private float damages;
    private Transform player;
    private float distToPlayer;
    private float range;
    private float explosionRange;
    private bool exploding;
    private float explosionDelay;
    private float explosionTime;

    public void init(float damages, Transform player)
    {
        this.damages = damages;
        this.player = player;
    }

    void Start()
    {
        range = 5f;
        exploding = false;
        explosionDelay = 1f;
        explosionRange = 10f;
    }

    void Update()
    {
        if(!exploding)
        {
            distToPlayer = Vector3.Distance(player.position, transform.position);
            if(distToPlayer <= range)
            {
                exploding = true;
                explosionTime = Time.time + explosionDelay;
            }
        }

        else
        {
            if(Time.time < explosionTime)
            {
                return;
            }

            Explode();
        }
    }

    private void Explode()
    {
        // TODO : Add explosion

        if(Vector3.Distance(transform.position, player.position) <= explosionRange)
        {
            // player.GetHit(damages);
        }

        Destroy(gameObject);
    }
}
