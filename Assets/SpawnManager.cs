using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //integretaed GameObject
    public GameObject enemyPreferb;
    public GameObject powerUpPreferb;

    //numbers
    private float spawnRange = 9.0f;
    public int enemyCount;
    public int waveNumber = 1;

    // Start is called before the first frame update


    void Start()
    {
        //number of enemies spawn
        spawnEnemyWave(waveNumber);
        Instantiate(powerUpPreferb, GenerateSpawnPosition(), powerUpPreferb.transform.rotation);
    }

    //four loop to spawn power up & enemies alsogenerating position
    void spawnEnemyWave(int EnemiesToSpawn)
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
        //calling Enemy
        enemyCount = FindObjectsOfType<Enemy>().Length;
    }

    //random position void Generated
    private Vector3 GenerateSpawnPosition()
    {
        float spawnprosX = Random.Range(-spawnRange, spawnRange);
        float spawnprosZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randompos = new Vector3(spawnprosX, 0, spawnprosZ);

        return randompos;

    }
}
