using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform spawnPos;

    [SerializeField]
    private int enemyCount = 0;
    [SerializeField]
    private int enemiesToSpawn = 10;
    [SerializeField]
    private float spawnTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
        /*for (int i = 0; i < spawnCount; i++)
        {
            Instantiate(enemyPrefab, spawnPos.position, Quaternion.identity);
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnEnemy()
    {
        for (int i = 0; i <= enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, spawnPos.position, Quaternion.identity);
            yield return new WaitForSeconds(spawnTime);
        }
        /*if (enemyCount <= enemiesToSpawn)
        {
            Instantiate(enemyPrefab, spawnPos.position, Quaternion.identity);
            enemyCount++;
        }*/
    }
}
