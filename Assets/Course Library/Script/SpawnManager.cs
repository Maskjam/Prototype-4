using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPerfab;
    public GameObject powerupPrefab;
    private float spawnRange = 9;
    // Start is called before the first frame update
    void Start()
    { 
       SpawnEnemyWave(3);
         Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);

       
    
    } 
    
    private Vector3 GenerateSpawnPosition()
    {
         float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0 , spawnPosZ);
        return randomPos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for(int i = 0; i < enemiesToSpawn; i++)
        {
             Instantiate(enemyPerfab, GenerateSpawnPosition(), enemyPerfab.transform.rotation);
        }
    }
}
