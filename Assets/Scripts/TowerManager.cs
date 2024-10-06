using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    public enum TowerType
    {
        Basic,
        ExplosiveTower,
        FireTower,
        Advanced,
        Size
    }

    // Put on shared prefab manager script.
    public GameObject[] towerPrefabs = new GameObject[(int)TowerType.Size];

}
