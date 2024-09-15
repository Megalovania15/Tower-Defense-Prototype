using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ButtonInteractions : MonoBehaviour
{
    public Vector3 towerPlacementPos;

    public GameObject associatedTower;

    public UnityEvent<TowerManager.TowerType> buttonPressed;

    public TowerManager.TowerType tower;

    private TMP_Text costDisplay;

    private List<PlatformInteractions> platforms = new List<PlatformInteractions>();

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] platformObjects = GameObject.FindGameObjectsWithTag("Platform");

        foreach(GameObject platformObject in platformObjects) 
        {
            platforms.Add(platformObject.GetComponent<PlatformInteractions>());
        }

        costDisplay = GetComponentInChildren<TMP_Text>();
        DisplayTowerPrice();
    }

    //purchases the tower associated with the specific button
    public void BuildTower()
    {
        foreach (var platform in platforms)
        {
            platform.BuildTower(tower);
        }

        //buttonPressed.Invoke(tower);
        //Instantiate(associatedTower, towerPlacementPos, Quaternion.identity);

    }

    //displays the price of the tower associated with the specific button
    void DisplayTowerPrice()
    {
        Tower towerScript = associatedTower.GetComponent<Tower>();
        costDisplay.text = towerScript.GetCost().ToString();
    }

    void FindPlacementPos()
    { 
        
    }

}
