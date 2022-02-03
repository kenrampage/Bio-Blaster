using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RangeDetector : MonoBehaviour
{
    private GameObject[] enemies;
    public float targetDistance;
    public bool inCombat;

    public bool InCombat
    {
        get { return inCombat; }
        set
        {
            if (inCombat != value)
            {
                if (value == true)
                {
                    print("Starting Combat");
                    onCombatStart?.Invoke();
                }
                else
                {
                    print("Ending Combat");
                    onCombatEnd?.Invoke();

                }

                inCombat = value;
            } 
        }
    }

    [SerializeField] private UnityEvent onCombatStart;
    [SerializeField] private UnityEvent onCombatEnd;

    private void Start()
    {
        InCombat = false;
    }

    private void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        CheckDistances();
    }

    private void CheckDistances()
    {
        foreach (var enemy in enemies)
        {
            if ((enemy.transform.position - transform.position).magnitude <= targetDistance && !inCombat)
            {
                InCombat = true;
                
                break;
            }
            else if ((enemy.transform.position - transform.position).magnitude <= targetDistance && inCombat)
            {
                break;
            }
            else if (inCombat)
            {
                InCombat = false;
                
            }

        }
    }
}
