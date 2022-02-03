using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bovid : FlyingEnemy
{

    public GameObject bombPrefab;

    private GameObject bombsList;
    private bool fleeing;
    private float fleeDistance;
    private Vector3 fleeTarget;
    private Vector3 fleeDirection;
    private Vector3 fleePosition;

    private float fleeDuration;
    

    public override void Awake()
    {
        fleeing = false;
        fleeDistance = 1f;
        enemyLayer = ~LayerMask.NameToLayer("Enemy");

        speed = 30f;
        visionDistance = 100f;
        fireRate = 0.5f;
        damages = 1f;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public override void Start()
    {
        // No start
    }

    public void SetBombList(GameObject bombList)
    {
        bombsList = bombList;
    }

    public override void Update()
    {
        base.Update();

        if(fleeing)
        {
            targetDistance = Vector3.Distance(transform.position, fleePosition);

            if(Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;

                SpawnBomb();
            }

            if(targetDistance > 1f)
            {
                transform.position = transform.position + fleeDirection * speed * Time.deltaTime;
            }

            else
            {
                fleeing = false;
            }
        }
    }

    private void SpawnBomb()
    {
        GameObject newBomb = Instantiate(bombPrefab, transform.position, Quaternion.identity);
        newBomb.transform.SetParent(bombsList.transform);
        newBomb.GetComponent<Bomb>().init(damages, player);
    }

    public override void Move()
    {
        // Flee when player too close
        int maxCount = 40;
        int count = 0;

        while(!fleeing && count < maxCount)
        {
            float randFactor = 1f;
            float randX = Random.Range(-randFactor, randFactor);
            float randY = Random.Range(-randFactor, randFactor);
            float randZ = Random.Range(-randFactor, randFactor);
            fleeDirection = new Vector3(randX, randY, randZ);

            RaycastHit hit;
            if(!Physics.Raycast(transform.position, fleeDirection, out hit, fleeDistance))
            {
                fleeing = true;
                fleePosition = transform.TransformPoint(fleeDirection * fleeDistance * 0.5f);
                //fleePosition = transform.position + fleeDirection * fleeDistance * 0.9f;
            }

            else
            {
                Debug.Log(hit.transform.name);
                Debug.Log("IN A WALL");
            }

            count ++;
        }
    }

    public override void Attack()
    {
        // Does not attack
    }
}
