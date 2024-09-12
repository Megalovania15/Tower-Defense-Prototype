using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformInteractions : MonoBehaviour
{
    public GameObject shopPanel;

    public ShopInteractions shop;

    public enum TowerType {
        Basic,
        Advanced,
        Size
    }

    // Put on shared prefab manager script.
    public GameObject[] towerPrefabs = new GameObject[(int)TowerType.Size];

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

    public void PurchaseTower(int tower)
    {
        Instantiate(towerPrefabs[tower], transform.position, Quaternion.identity);
        //Instantiate(associatedTower, towerPlacementPos, Quaternion.identity);
        Debug.Log("Tower " + tower + " built");
    }

    void OnMouseDown()
    {
        shopPanel.SetActive(true);
        ShopInteractions shopInteractions = shop.GetComponent<ShopInteractions>();
        shopInteractions.towerPlacementPos = GetPosition();
        Debug.Log(shopInteractions.towerPlacementPos);
    }
}
