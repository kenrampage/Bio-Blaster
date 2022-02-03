using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikyBoi : FlyingEnemy
{
    public GameObject selfPrefab;
    
    private Transform enemylist;
    private float duplicateDelay;
    private float nextDuplication;
    private Vector3 spawnPosition;
    private float spawnDistance;
    private Vector3 spawnDirection;

    public override void Awake()
    {
        duplicateDelay = Random.Range(10f, 20f);
        nextDuplication = Time.time + duplicateDelay;
        spawnDistance = 3f;

        damages = 2f;
        speed = 2f;
        attackRange = 0.6f;
        followUntil = 0.5f;
        visionDistance = 20f;
        fireRate = 1f;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public override void Start()
    {
        // Your princess is in another castle
    }

    public void SetEnemyList(GameObject list)
    {
        enemylist = list.transform;
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

            GameObject g = Instantiate(selfPrefab, spawnPosition, Quaternion.identity);
            g.transform.SetParent(enemylist);
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
            player.GetComponent<PlayerHealth>().GetHit(damages);
        }

    }
}
