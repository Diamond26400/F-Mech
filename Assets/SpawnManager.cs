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
    private bool playerLeftPlane = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerLeftPlane = false;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Player exited the trigger, trigger game over
            GameOver();
        }
        else if (other.CompareTag("Enemy"))
        {
            // Enemy exited the trigger, spawn a new wave
            SpawnNewWave();
        }
    }
    void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if (playerLeftPlane && enemyCount == 0 && waveManager != null)
        {
            float currentEnemySpeed = waveManager.GetEnemySpeedForCurrentWave();

            if (enemyPrefab != null)
            {

                StartCoroutine(SpawnEnemyWaveCoroutine(waveCount, currentEnemySpeed));
            }
            else
            {
                Debug.LogError("Enemy prefab is not assigned to the SpawnManagerX script.");
            }
        }
    }
    void GameOver()
    {
        // Implement your game over logic here
        Debug.Log("Game Over");
        // You might want to show a game over screen, reset the level, etc.
    }

    void SpawnNewWave()
    {
        // Implement your logic to spawn a new wave
        Debug.Log("Spawning new wave");
        // You can call your existing spawning logic here
    }

    IEnumerator SpawnEnemyWaveCoroutine(int enemiesToSpawn, float enemySpeed)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            GameObject newEnemy = Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);

            if (newEnemy != null)
            {
                Enemy enemyScript = newEnemy.GetComponent<Enemy>();
                if (enemyScript != null)
                {
                    enemyScript.speed = enemySpeed;
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

            yield return null;
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

    Vector3 GenerateSpawnPosition()
    {
        float xPos = Random.Range(-spawnRangeX, spawnRangeX);
        float zPos = Random.Range(spawnZMin, spawnZMax);
        return new Vector3(xPos, 0, zPos);
    }
}



