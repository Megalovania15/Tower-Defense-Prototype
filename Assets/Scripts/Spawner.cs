using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform spawnPos;
    public int spawnCount = 10;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            Instantiate(enemyPrefab, spawnPos.position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
