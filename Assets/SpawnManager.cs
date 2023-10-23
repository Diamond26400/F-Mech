using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPreferb;
    private float spawnRange = 9.0f;
    // Start is called before the first frame update
    void Start()
    {

        Instantiate(enemyPreferb, GenerateSpawnPosition(), enemyPreferb.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private Vector3 GenerateSpawnPosition()
    {
        float spawnprosX = Random.Range(-spawnRange, spawnRange);
        float spawnprosZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randompos = new Vector3(spawnprosX, 0, spawnprosZ);

        return randompos;

    }
}
