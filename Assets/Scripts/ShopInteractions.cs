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

    //purchases the tower associated with the specific button
    public void PurchaseTower(GameObject associatedTower)
    {
        Instantiate(associatedTower, towerPlacementPos, Quaternion.identity);
    }

    //displays the price of the tower associated with the specific button
    public void DisplayTowerPrice(Tower associatedTower)
    {
        TMP_Text costDisplay = FindButtonText();
        costDisplay.text = associatedTower.GetCost().ToString();
    }

    public TMP_Text FindButtonText()
    {
        TMP_Text costDisplay = GetComponentInChildren<TMP_Text>();
        return costDisplay;
    }

    public void ExitShop()
    {
        shopPanel.SetActive(false);
    }
}
