using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformInteractions : MonoBehaviour
{
    public GameObject shopPanel;

    public ShopInteractions shop;

    public TowerManager towerManager;

    public MoneyTracker moneyTracker;

    public bool isSelected = false;

    private Vector3 platformPosition;

    public Vector3 GetPosition()
    {
        Debug.Log(platformPosition);
        platformPosition = transform.position;
        return platformPosition;

    }

    // Start is called before the first frame update
    void Start()
    {
        shopPanel.SetActive(false);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //calls the function to build a tower from the list of tower prefabs in the tower manager
    public void BuildTower(TowerManager.TowerType tower)
    {
        GameObject towerToSpawn = towerManager.towerPrefabs[(int)tower];
        int cost = towerToSpawn.GetComponent<Tower>().GetCost();

        if (isSelected && moneyTracker.RemoveMoney(cost))
        {
            Instantiate(towerToSpawn, transform.position, Quaternion.identity);
            Debug.Log("Tower " + tower + " built");
        }

        isSelected = false;
    }

    //when clicking the platform, bring up the shop menu and build the tower when the player clicks on the
    //button
    void OnMouseDown()
    {
        shopPanel.SetActive(true);
        isSelected = true;
        /*ShopInteractions shopInteractions = shop.GetComponent<ShopInteractions>();
        shopInteractions.towerPlacementPos = GetPosition();
        Debug.Log(shopInteractions.towerPlacementPos);*/
    }
}
