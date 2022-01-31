using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindNearestEnemy : MonoBehaviour
{
    public float closestDistance;
    public GameObject[] enemies;

    // Start is called before the first frame update
    void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach(GameObject enemy in enemies)
        {
            var distance = (enemy.transform.position - transform.position).magnitude;
            if(distance <= closestDistance)
            {
                closestDistance = distance;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
