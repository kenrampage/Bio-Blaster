using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RangeDetector : MonoBehaviour
{
    private GameObject[] enemies;
    public float targetDistance;
    public int enemiesInRange;

    public bool enemiesInRangeBool;

    [SerializeField] private SOBool soBool;

    [SerializeField] private UnityEvent onCombatStart;
    [SerializeField] private UnityEvent onCombatEnd;

    private void Start()
    {
        enemiesInRange = 0;
    }

    private void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        CheckDistances();
    }

    private void CheckDistances()
    {
        enemiesInRange = 0;

        foreach (var enemy in enemies)
        {
            if ((enemy.transform.position - transform.position).magnitude <= targetDistance)
            {
                enemiesInRange++;
            }
        }

        if (enemiesInRange > 0)
        {
            soBool.SetValue(true);
            enemiesInRangeBool = true;
            onCombatStart?.Invoke();
        }
        else
        {
            soBool.SetValue(false);
            enemiesInRangeBool = false;
            onCombatEnd?.Invoke();
        }

    }
}
