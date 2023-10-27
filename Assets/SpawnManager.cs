using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPreferb;
    private float spawnRange = 9.0f;
    public int enemyCount ;
    public int waveNumber = 1;
    public GameObject powerUpPreferb;
    // Start is called before the first frame update


    void Start()
    {
        spawnEnemyWave(waveNumber);
        Instantiate(powerUpPreferb, GenerateSpawnPosition(), powerUpPreferb.transform.rotation);
    }

    void spawnEnemyWave(int EnemiesToSpawn )
    {
        for (int waveNumber = 0; waveNumber < EnemiesToSpawn; waveNumber++)
        {
             
            Instantiate(enemyPreferb, GenerateSpawnPosition(), enemyPreferb.transform.rotation);
            if (enemyCount == 0)
            {
                spawnEnemyWave(waveNumber);
                Instantiate(powerUpPreferb, GenerateSpawnPosition(), powerUpPreferb.transform.rotation);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
    }
    private Vector3 GenerateSpawnPosition()
    {
        float spawnprosX = Random.Range(-spawnRange, spawnRange);
        float spawnprosZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randompos = new Vector3(spawnprosX, 0, spawnprosZ);

        return randompos;

    }
}
