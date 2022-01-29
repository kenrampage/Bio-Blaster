using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    float lightWpnWaitTime;
    float heavyWpnWaitTime;

    [SerializeField] GameObject rocketPrefab;

    //0 = light weapon 1 | 1 = light weapon 2 | 2 = heavy weapon 1
    [SerializeField] GameObject[] firePoints;
    //Same order as above
    RaycastHit[] weaponHit = {new RaycastHit(), new RaycastHit(), new RaycastHit() };

    void Start()
    {
        
    }

    void Update()
    {
        lightWpnWaitTime -= Time.deltaTime;
        heavyWpnWaitTime -= Time.deltaTime;

        //Light attack, which is faster to use.
        if (Input.GetMouseButtonDown(0))
        {
            if (lightWpnWaitTime < 0)
            {
                Debug.Log("SmallPew");
                lightWpnWaitTime = 0.2f;
                for (int i = 0; i < 2; i++)
                {
                    if (Physics.Raycast(firePoints[0].transform.position, transform.forward, out weaponHit[0], 1000))
                    {
                        if (weaponHit[i].transform.gameObject != null)
                        {
                            if (weaponHit[i].transform.tag == "Enemy")
                            {
                                //ADD ENEMY DAMAGE HERE!
                            }
                        }
                    }
                }
            }
        }
        //This is the heavy attack, which takes longer to reload.
        if (Input.GetMouseButtonDown(1))
        {
            if (heavyWpnWaitTime < 0)
            {
                GameObject rocket = Instantiate(rocketPrefab, firePoints[2].transform.position, transform.rotation);
                rocket.transform.Rotate(180, 0, 0);
                heavyWpnWaitTime = 3f;
            }
        }
    }
}
