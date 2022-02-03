using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adenovirus : FlyingEnemy
{
    private float moveRate;
    private float moveDuration;
    private WaitForSeconds waitMoveDuration;
    private float nextMove;
    private bool moving;

    public override void Awake()
    {
        speed = 15f;
        moveRate = Random.Range(0.3f, 0.6f);
        moving = false;
        moveDuration = Random.Range(0.1f, 0.3f);
        waitMoveDuration = new WaitForSeconds(moveDuration);

        attackRange = 2f;
        followUntil = 1f;
        visionDistance = 20f;
        fireRate = 0.5f;
        damages = 1f;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    override public void Move()
    {

        float randFactor = 5f;
        float randX = Random.Range(-randFactor, randFactor);
        float randY = Random.Range(-randFactor, randFactor);
        float randZ = Random.Range(-randFactor, randFactor);

        Vector3 randTargetPosition = new Vector3(player.position.x + randX, player.position.y + randY, player.position.z + randZ);
        Vector3 randTargetDirection = Vector3.Normalize(randTargetPosition - transform.position);

        if(moving)
        {
            transform.position = transform.position + randTargetDirection * speed * Time.deltaTime;
        }

        else if(targetDistance > followUntil && Time.time > nextMove)
        {
            nextMove = Time.time + moveRate + moveDuration;
            StartCoroutine(Impulse());        
        }

    }

    private IEnumerator Impulse()
    {
        moving = true;

        yield return waitMoveDuration;

        moving = false;
    }
}
