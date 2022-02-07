using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemyManager : MonoBehaviour
{
    public List<GameObject> enemyPrefabs;
    public List<Transform> organs;

    private GameObject bombList;
    private float waveDelay;
    private float nextWave;

    // How many waves next tick
    private float nextWaveNumber;

    // How many enemies per waves next tick
    private float nextEnemyWaveNumber;
    private Vector3 spawnDirection, spawnPosition;
    private float spawnDistance;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        bombList = new GameObject("bombList");
        bombList.transform.position = Vector3.zero;

        nextWaveNumber = 1;
        nextEnemyWaveNumber = 1;
        waveDelay = 20f;

        // foreach (Transform g in organs)
        // {
        //     Debug.Log(g.position);
        // }
    }

    void FixedUpdate()
    {
        if(Time.time > nextWave)
        {
            waveDelay = Mathf.Clamp(waveDelay-1, 5f, waveDelay);
            nextWave = Time.time + waveDelay;
            nextEnemyWaveNumber += 1;
            SpawnWaves();
        }
    }

    private void SpawnWaves()
    {
        for(int i = 0; i < nextWaveNumber; i++)
        {
            SpawnWave();
        }
    }

    private void SpawnWave()
    {
        int i = organs.Count;
        Transform spawnPoint = organs.ElementAt(Random.Range(0, organs.Count));
        Vector3 currentRoomPoint = spawnPoint.position;
        //Debug.Log(currentRoomPoint);
        GameObject enemyspawn = enemyPrefabs.ElementAt(Random.Range(0, enemyPrefabs.Count));

        for(int j = 0; j < nextEnemyWaveNumber; j++)
        {
            Spawn(enemyspawn, currentRoomPoint, spawnPoint);
        }
    }

    private void Spawn(GameObject prefab, Vector3 position, Transform t)
    {
        float randFactor = 1f;
        float randX = Random.Range(-randFactor, randFactor);
        float randY = Random.Range(-randFactor, randFactor);
        float randZ = Random.Range(-randFactor, randFactor);

        spawnDistance = Random.Range(5f, 8f);
        spawnDirection = new Vector3(randX, randY, randZ);
        spawnPosition = position + spawnDirection * spawnDistance;

        GameObject newEnemy = Instantiate(prefab, spawnPosition, Quaternion.identity);
        newEnemy.transform.SetParent(transform);

        Bovid b = newEnemy.GetComponent<Bovid>();
        SpikyBoi s = newEnemy.GetComponent<SpikyBoi>();
        Adenovirus a = newEnemy.GetComponent<Adenovirus>();
        FlyingEnemy e = newEnemy.GetComponent<FlyingEnemy>();

        if(b)
        {
            b.SetBombList(bombList);
            b.organ = t;
        }

        else if (s)
        {
            s.SetEnemyList(gameObject);
            s.organ = t;
        }

        else if (a)
        {
            a.organ = t;
        }

        else if (e)
        {
            e.organ = t;
        }
    }
}
