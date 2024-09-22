using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public Sprite towerSprite;

    [SerializeField]
    private int cost;

    public int GetCost()
    {
        return cost;
    }

    // Start is called before the first frame update
    void Start()
    {
        towerSprite = GetComponent<SpriteRenderer>().sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    //Finds targets to shoot at in the list of targets provided by the trigger collider
    //to be updated with several modes such as shooting the first or last enemy in range,
    //the strongest enemy, the weakest enemy, the enemy with the most or least health
    
}
