using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ButtonInteractions : MonoBehaviour
{
    public Vector3 towerPlacementPos;

    public GameObject associatedTower;

    public UnityEvent<Tower> buttonPressed;

    private TMP_Text costDisplay;

    public Tower tower;

    // Start is called before the first frame update
    void Start()
    {
        costDisplay = GetComponentInChildren<TMP_Text>();
        DisplayTowerPrice();
    }

    //purchases the tower associated with the specific button
    public void PurchaseTower()
    {
        buttonPressed.Invoke(tower);
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
