using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.Linq;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform spawnPos;
    public TMP_Text waveText;
    public TMP_Text waveTimer;

    [SerializeField]
    private SpawnGroup[] spawnGroups;
    //[SerializeField]
    //private int enemiesToSpawn = 10;
    //[SerializeField]
    //private float spawnTime = 1f;
    //[SerializeField]
    //private float timeToNextWave = 60f;
    private int waveCount = 0;
    //[SerializeField]
    private int totalWaves = 0;

    // Start is called before the first frame update
    void Start()
    {
        /*totalWaves = spawnGroups.Where((SpawnGroup spawnGroup) => {
                return spawnGroup.isNewWave; 
            }).Count();*/

        foreach (SpawnGroup spawnGroup in spawnGroups)
        {
            if (spawnGroup.isNewWave)
            {
                totalWaves++;
            }
        }

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
        while (waveCount < totalWaves)
        {
            foreach (SpawnGroup spawnGroup in spawnGroups)
            {
                if (spawnGroup.isNewWave)
                {
                    var temp = spawnGroup.delayBeforeSpawns;
                    while (temp > 0)
                    {
                        waveTimer.gameObject.SetActive(true);
                        temp -= waveTimerTick;

                        int seconds = Mathf.FloorToInt(temp % 60);
                        int minutes = Mathf.FloorToInt(temp / 60);

                        waveTimer.text = "Next Wave: " + string.Format("{0:00}:{1:00}", minutes, seconds);

                        yield return new WaitForSecondsRealtime(waveTimerTick);
                    }

                    waveCount++;
                    waveText.text = "Wave " + waveCount;
                    waveTimer.gameObject.SetActive(false);
                    //StartCoroutine(WaveTimer(spawnGroup.delayBeforeSpawns));
                }
                else 
                {
                    yield return new WaitForSeconds(spawnGroup.delayBeforeSpawns);
                }
                

                for (int i = 0; i < spawnGroup.enemiesToSpawn; i++)
                {
                    Instantiate(spawnGroup.enemyPrefab, spawnPos.position, Quaternion.identity);

                    if (i != spawnGroup.enemiesToSpawn - 1)
                    {
                        yield return new WaitForSeconds(spawnGroup.delayBetweenSpawns);
                    }
                }
            }
        }
        
        /*while (waveCount <= totalWaves)
        {
            var temp = timeToNextWave;
            waveTimer.gameObject.SetActive(false);

            for (int i = 0; i <= enemiesToSpawn; i++)
            {   
                //Debug.Log("Spawning for wave " + waveCount);
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
        }*/
        
    }

    IEnumerator WaveTimer(float timeToNextWave)
    {
        float waveTimerTick = 1f;
        var temp = timeToNextWave;
        waveTimer.gameObject.SetActive(false);

        while (temp > 0)
        {
            waveTimer.gameObject.SetActive(true);
            temp -= waveTimerTick;

            int seconds = Mathf.FloorToInt(temp % 60);
            int minutes = Mathf.FloorToInt(temp / 60);

            waveTimer.text = "Next Wave: " + string.Format("{0:00}:{1:00}", minutes, seconds);

            yield return new WaitForSecondsRealtime(waveTimerTick);
        }
    }
}
