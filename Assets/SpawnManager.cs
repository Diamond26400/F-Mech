using System.Collections;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    public WaveManager waveManager; // Assign the WaveManager in the Inspector

    private float spawnRangeX = 10;
    private float spawnZMin = 15;
    private float spawnZMax = 25;

    public int enemyCount;
    public int waveCount = 1;

    public GameObject player;

    void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if (enemyCount == 0 && waveManager != null)
        {
            float currentEnemySpeed = waveManager.GetEnemySpeedForCurrentWave();

            if (enemyPrefab != null)
            {
                // Call a method to spawn the enemy wave with the updated speed
                SpawnEnemyWave(waveCount, currentEnemySpeed);
            }
            else
            {
                Debug.LogError("Enemy prefab is not assigned to the SpawnManagerX script.");
            }
        }
    }

    Vector3 GenerateSpawnPosition()
    {
        float xPos = Random.Range(-spawnRangeX, spawnRangeX);
        float zPos = Random.Range(spawnZMin, spawnZMax);
        return new Vector3(xPos, 0, zPos);
    }

    void SpawnEnemyWave(int enemiesToSpawn, float enemySpeed)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            GameObject newEnemy = Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);

            if (newEnemy != null)
            {
                Enemy enemyScript = newEnemy.GetComponent<Enemy>();
                if (enemyScript != null)
                {
                    enemyScript.speed = enemySpeed; // Set the enemy speed
                }
                else
                {
                    Debug.LogError("Enemy script is missing on the spawned enemy.");
                }
            }
            else
            {
                Debug.LogError("Failed to instantiate enemy prefab.");
            }
        }

        waveCount++;
        ResetPlayerPosition();
    }

    void ResetPlayerPosition()
    {
        player.transform.position = new Vector3(0, 1, -7);
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        player.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }
}

