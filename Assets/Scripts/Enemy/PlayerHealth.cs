using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    private float maxLife;
    public float currentLife;
    private float regen;
    private float regenRate;
    private float nextRegen;
    private bool isAlive;

    [SerializeField] private UnityEvent onLevelEnd;


    void Start()
    {
        isAlive = true;
        maxLife = 40f;
        currentLife = maxLife;

        regen = 0.5f;
        regenRate = 1f;

    }

    void Update()
    {

        if (currentLife <= 0f && isAlive)
            {
                isAlive = false;
                onLevelEnd?.Invoke();
            }

            else if (Time.time >= nextRegen)
            {
                // Debug.Log("REGEN : " + currentLife);
                nextRegen = Time.time + regenRate;
                currentLife += 1f;
                if (currentLife > maxLife)
                {
                    currentLife = maxLife;
                }
            }
    }

    public void GetHit(float damage)
    {
        currentLife = Mathf.Clamp(currentLife - damage, 0f, maxLife);

    }
}
