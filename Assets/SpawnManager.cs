using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPreferb;
    private float spawnRange = 9.0f;
    public int enemyCount ;
    // Start is called before the first frame update


    void Start()
    {
        spawnEnemyWave(3);

    }

    void spawnEnemyWave(int EnemiesToSpawn )
    {
        for (int i = 0; i< EnemiesToSpawn; i++)
        {
             
            Instantiate(enemyPreferb, GenerateSpawnPosition(), enemyPreferb.transform.rotation);
            if (enemyCount == 0)
            {
                spawnEnemyWave(1);

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
