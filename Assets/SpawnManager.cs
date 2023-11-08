using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs; // Array of different enemy prefabs
    public GameObject powerUpPrefab;


    private float spawnRange = 9.0f;
    public int enemyCount;
    public int waveNumber = 1;


    void Start()
    {
        spawnEnemyWave(waveNumber);
        Instantiate(powerUpPrefab, GenerateSpawnPosition(), powerUpPrefab.transform.rotation);
    }

    void spawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            // Randomly select an enemy prefab
            int randomIndex = Random.Range(0, enemyPrefabs.Length);
            GameObject selectedEnemyPrefab = enemyPrefabs[randomIndex];

            Vector3 spawnPosition = GenerateSpawnPosition();
            Instantiate(selectedEnemyPrefab, spawnPosition, selectedEnemyPrefab.transform.rotation);
        }
    }

    void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;


        if (enemyCount == 0)
        {
            waveNumber++;
            spawnEnemyWave(waveNumber);
            Instantiate(powerUpPrefab, GenerateSpawnPosition(), powerUpPrefab.transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);

        return randomPos;
    }
}

