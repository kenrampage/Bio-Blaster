using UnityEngine;
using UnityEngine.Events;

public class OrganHealthTracker : MonoBehaviour
{
    [SerializeField] OrganHealth[] organs;
    public float totalOrganHealth;
    public bool organsAlive = true;

    [SerializeField] private UnityEvent onOrganDeath;

    private void Update()
    {
        totalOrganHealth = organs[0].currentLife + organs[1].currentLife + organs[2].currentLife + organs[3].currentLife;

        if (organsAlive && totalOrganHealth <= 0)
        {
            organsAlive = false;
            onOrganDeath?.Invoke();
        }
    }


}
