using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyTracker : MonoBehaviour
{
    private int money = 0;

    private TMP_Text moneyText;

    // Start is called before the first frame update
    void Start()
    {
        moneyText = GetComponent<TMP_Text>();
        moneyText.text = "Money: " + money.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CollectMoney(int min, int max)
    {
        money += Random.Range(min, max);

        moneyText.text = "Money: " + money.ToString();
    }
}
