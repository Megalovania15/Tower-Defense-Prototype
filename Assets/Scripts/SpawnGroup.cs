using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

[CreateAssetMenu]
public class SpawnGroup : ScriptableObject
{
    public GameObject enemyPrefab;
    public int enemiesToSpawn;
    public float delayBetweenSpawns;
    public float delayBeforeSpawns;
    public bool isNewWave;
}
