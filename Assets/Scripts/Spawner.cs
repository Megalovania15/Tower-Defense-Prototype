using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform spawnPos;
    public TMP_Text waveText;

    [SerializeField]
    private int enemiesToSpawn = 10;
    [SerializeField]
    private float spawnTime = 1f;
    [SerializeField]
    private float timeToNextWave = 60f;
    [SerializeField]
    private int waveCount = 1;
    [SerializeField]
    private int totalWaves = 10;

    // Start is called before the first frame update
    void Start()
    {
        waveText.text = "Wave " + waveCount;

        //this starts the coroutine. It can also be started by going StartCoroutine("SpawnEnemy")
        StartCoroutine(SpawnEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    //spawns an enemy after a set amount of time. Enemies spawn in waves. Additional functionality to be
    //added would be spawning different enemy types at different waves, adding a display of the time to
    //the next wave and increasing the number of enemies spawned based on the current wave for scaling
    //difficulty (may require a formula)
    IEnumerator SpawnEnemy()
    {
        while (waveCount <= totalWaves)
        {
            for (int i = 0; i <= enemiesToSpawn; i++)
            {
                Debug.Log("Spawning for wave " + waveCount);
                Instantiate(enemyPrefab, spawnPos.position, Quaternion.identity);
                yield return new WaitForSeconds(spawnTime);
            }
            waveCount++;
            waveText.text = "Wave " + waveCount;
            yield return new WaitForSeconds(timeToNextWave);
        }
        
    }

    //in Coroutines, yield statements can be used to insert a pause into the loop
    //yield return null = suspends coroutine until the next frame
    //yield return new WaitForSeconds(float)/WaitForSecondsRealtime(float)
    //= delays a function for a number of seconds while it's running
    //yield return new WaitForEndOfFrame() = useful if you want to for example, take a screenshot
    //essentially waits until after the frame has been rendered. And others..
    //Coroutine stops automatically after the end of the code, but can also type StopCoroutine()
    //or StopAllCoroutines()
}
