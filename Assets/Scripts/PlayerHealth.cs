using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxLife;
    public float currentLife;

    void Start()
    {
        maxLife = 20f;
        currentLife = maxLife;
    }

    void Update()
    {
        if(currentLife <= 0f)
        {
            // Show death screen
        }
    }

    public void GetHit(float damage)
    {
        currentLife = Mathf.Clamp(currentLife-damage, 0f, maxLife);
    }
}
