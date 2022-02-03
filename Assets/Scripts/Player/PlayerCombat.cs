 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCombat : MonoBehaviour
{
    float heavyWpnWaitTime;

    bool canShoot;

    [SerializeField] private UnityEvent onLaserFire;
    [SerializeField] private UnityEvent onRocketFire;
 
    [SerializeField] GameObject rocketPrefab;

    //0 = light weapon 1 | 1 = light weapon 2 | 2 = heavy weapon 1
    [SerializeField] GameObject[] firePoints;
    //Same order as above
    RaycastHit[] weaponHit = {new RaycastHit(), new RaycastHit(), new RaycastHit() };

    [SerializeField] GameObject laser;

    [SerializeField] float laserDamage;

    void Start()
    {
        canShoot = true;
    }

    void Update()
    {
        heavyWpnWaitTime -= Time.deltaTime;

        //Light attack, which is faster to use.
        if (Input.GetMouseButton(0))
        {
            if (canShoot)
            {
                // Debug.Log("1");
                for (int i = 0; i < 2; i++)
                {
                    // Debug.Log("2");
                    Instantiate(laser, firePoints[i].transform.position, transform.rotation);
                    onLaserFire?.Invoke();
                    if (Physics.Raycast(firePoints[i].transform.position, transform.forward, out weaponHit[i], 1000))
                    {
                        // Debug.Log("3");
                        if (weaponHit[i].transform.gameObject != null)
                        {
                            if (weaponHit[i].transform.tag == "Enemy")
                            {
                                // Debug.Log(weaponHit[i].transform.gameObject.name);
                                weaponHit[i].transform.gameObject.GetComponent<EnemyHealth>().health -= laserDamage;
                            }
                        }
                    }
                }
                canShoot = false;
                StartCoroutine(ShootDelay());
            }
        }
        //This is the heavy attack, which takes longer to reload.
        if (Input.GetMouseButtonDown(1))
        {
            if (heavyWpnWaitTime < 0)
            {
                GameObject rocket = Instantiate(rocketPrefab, firePoints[2].transform.position, transform.rotation);
                onRocketFire?.Invoke();
                rocket.transform.Rotate(180, 0, 0);
                heavyWpnWaitTime = 3f;
            }
        }
        
    }
    IEnumerator ShootDelay()
    {
        Debug.Log("Passed through shotdelay");
        yield return new WaitForSeconds(0.3f);
        canShoot = true;
    }
}
