using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrganHealth : MonoBehaviour
{
    private float maxLife;
    public float currentLife;

    void Start()
    {
        maxLife = 1000f;
        currentLife = maxLife;
    }

    void Update()
    {
        if(currentLife <= 0f)
        {
            Destroy(gameObject);
        }
    }

    public void GetHit(float damage)
    {
        currentLife = Mathf.Clamp(currentLife-damage, 0f, maxLife);
    }
}
