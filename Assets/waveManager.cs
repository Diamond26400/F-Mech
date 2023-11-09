using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public WaveManager[] waves;
    private int currentWave = 0;
    public float enemySpeed;
    public float GetEnemySpeedForCurrentWave()
    {
        if (currentWave < waves.Length)
        {
            return waves[currentWave].enemySpeed;
        }

        return 0f; // Default speed if all waves have been completed
    }

    public void AdvanceToNextWave()
    {
        currentWave++;
    }
}