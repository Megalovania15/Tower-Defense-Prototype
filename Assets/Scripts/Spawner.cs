using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform spawnPos;
    public TMP_Text waveText;
    public TMP_Text waveTimer;

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
        waveTimer.gameObject.SetActive(false);

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
    IEnumerator SpawnEnemy(float waveTimerTick = 1f)
    {
        while (waveCount <= totalWaves)
        {
            var temp = timeToNextWave;
            waveTimer.gameObject.SetActive(false);

            for (int i = 0; i <= enemiesToSpawn; i++)
            {   
                Debug.Log("Spawning for wave " + waveCount);
                Instantiate(enemyPrefab, spawnPos.position, Quaternion.identity);
                yield return new WaitForSeconds(spawnTime);
            }
            waveCount++;
            waveText.text = "Wave " + waveCount;

            //is a little timer that is used to display a countdown to the next wave
            while (temp > 0)
            {
                waveTimer.gameObject.SetActive(true);
                temp -= waveTimerTick;

                int seconds = Mathf.FloorToInt(temp % 60);
                int minutes = Mathf.FloorToInt(temp / 60);

                waveTimer.text = "Next Wave: " + string.Format("{0:00}:{1:00}", minutes, seconds);

                yield return new WaitForSecondsRealtime(waveTimerTick);
            }
            
            //yield return new WaitForSeconds(timeToNextWave);
        }
        
    }
}
