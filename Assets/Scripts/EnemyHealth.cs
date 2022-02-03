using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float pointsWorth;
    public float health;
    [SerializeField] ParticleSystem deathSplatter;
    PanelsInCockpit scoreAdder;
    // Start is called before the first frame update
    [SerializeField] private GameObject explosionSoundPrefab;


    void Start()
    {
        scoreAdder = GameObject.FindGameObjectWithTag("Player").GetComponent<PanelsInCockpit>();    
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            scoreAdder.score += pointsWorth;
            Instantiate(deathSplatter, transform.position, Quaternion.identity);
            Instantiate(explosionSoundPrefab,transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
