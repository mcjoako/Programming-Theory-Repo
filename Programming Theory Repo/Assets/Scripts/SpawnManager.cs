using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject redEnemyPrefab;
    public GameObject orangeEnemyPrefab;
    public GameObject yellowEnemyPrefab;
    public int enemies = 50;
    private float spawnRangeXRight = 12;
    private float spawnRangeXLeft = -17;
    private float spawnZMin = -18; // set min spawn Z
    private float spawnZMax = -26; // set max spawn Z
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(enemies);

    }

    // Update is called once per frame
    void Update()
    {

    }

    Vector3 GenerateSpawnPosition()
    {
        float xPos = Random.Range(spawnRangeXLeft, spawnRangeXRight);
        float zPos = Random.Range(spawnZMin, spawnZMax);
        return new Vector3(xPos, 10, zPos);
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for(int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(redEnemyPrefab, GenerateSpawnPosition(), redEnemyPrefab.transform.rotation);
            Instantiate(orangeEnemyPrefab, GenerateSpawnPosition(), orangeEnemyPrefab.transform.rotation);
            Instantiate(yellowEnemyPrefab, GenerateSpawnPosition(), yellowEnemyPrefab.transform.rotation);

        }
        

    }
}
