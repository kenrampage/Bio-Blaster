using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikyBoi : FlyingEnemy
{
    public GameObject selfPrefab;
    private float duplicateDelay;
    private float nextDuplication;
    private Vector3 spawnPosition;
    private float spawnDistance;
    private Vector3 spawnDirection;

    public override void Awake()
    {
        duplicateDelay = Random.Range(4f, 8f);
        nextDuplication = Time.time + duplicateDelay;
        spawnDistance = 3f;

        damages = 2f;
        speed = 6f;
        attackRange = 3f;
        followUntil = 1f;
        visionDistance = 40f;
        fireRate = 1f;
    }

    public override void Start()
    {
        // Your princess is in another castle
    }

    public override void Update()
    {
        base.Update();

        if(Time.time > nextDuplication)
        {
            duplicateDelay = Random.Range(6f, 10f);
            nextDuplication = Time.time + duplicateDelay;
            
            Duplicate();
        }
    }

    private void Duplicate()
    {
        float randFactor = 1f;
        float randX = Random.Range(-randFactor, randFactor);
        float randY = Random.Range(-randFactor, randFactor);
        float randZ = Random.Range(-randFactor, randFactor);

        spawnDirection = new Vector3(randX, randY, randZ);

        if(!Physics.Raycast(transform.position, spawnDirection, spawnDistance))
        {
            spawnPosition = transform.position + spawnDirection * spawnDistance;

            Instantiate(selfPrefab, spawnPosition, Quaternion.identity);
        }
    }

    public override void Move()
    {
        if(targetDistance > followUntil)
        {
            transform.position = transform.position + targetDirection * speed * Time.deltaTime;
        }
    }

    public override void Attack()
    {
        if(targetDistance <= attackRange && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            //player.GetHit(damages);
        }

    }
}
