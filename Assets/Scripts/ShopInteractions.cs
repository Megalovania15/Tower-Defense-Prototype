using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopInteractions : MonoBehaviour
{
    public GameObject shopPanel;

    public Vector3 towerPlacementPos;

    /*public void PreviewTower()
    {
        
        SpriteRenderer previewTower = Instantiate(chosenTower.GetComponent<SpriteRenderer>(), towerPlacementPos, Quaternion.identity);
        previewTower.color = new Color(0, 0, 0, 0.5f);
    }*/

    /*public GameObject CreateTower(GameObject chosenTower)
    { 
        GameObject createdTower = Instantiate(chosenTower, towerPlacementPos, Quaternion.identity);
        createdTower.SetActive(false);
        return createdTower;
    }*/

    /*public void SetAssociatedPlatform(PlatformInteractions associatedPlatform)
    {
        towerPlacementPos = associatedPlatform.GetPosition();
        Debug.Log("Got the position of the platform");
    }*/

    public Vector3 GetTowerPos()
    {
        return towerPlacementPos;
    }

    public void ExitShop()
    {
        shopPanel.SetActive(false);
    }
}
