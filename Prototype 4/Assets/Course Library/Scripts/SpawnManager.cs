using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Components
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    // Tuning
    public float spawnRange = 9.0f;
    public int enemyCount;
    public int waveNumber = 1;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            SpawnEnemyWave(waveNumber);
            waveNumber++;
        }
    }
    // Random Spawnposition
    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange,spawnRange);
        float spawnPosZ = Random.Range(-spawnRange,spawnRange);
        Vector3 spawnPos = new Vector3(spawnPosX,0,spawnPosZ);
        return spawnPos;
    }

    // Spawn Enemies
    void SpawnEnemyWave(int enemiesToSpawn)
    {
        // Powerup Spawn makes more sense down here
        Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            // Instantiate Enemy
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }


}
