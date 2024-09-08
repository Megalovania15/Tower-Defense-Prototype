using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformInteractions : MonoBehaviour
{
    public GameObject shopPanel;

    public ShopInteractions shop;

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

    void OnMouseDown()
    {
        shopPanel.SetActive(true);
        ShopInteractions shopInteractions = shop.GetComponent<ShopInteractions>();
        shopInteractions.towerPlacementPos = GetPosition();
        Debug.Log(shopInteractions.towerPlacementPos);
    }
}
