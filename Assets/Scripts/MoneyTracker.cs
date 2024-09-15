using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyTracker : MonoBehaviour
{
    public TMP_Text moneyText;
    public TMP_Text warningText;

    [SerializeField]
    private int money = 0;

    public int GetMoney()
    {
        return money;
    }

    // Start is called before the first frame update
    void Start()
    {
        moneyText.text = "Money: " + money.ToString();
        warningText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CollectMoney(int moneyAmount)
    {
        money += moneyAmount;

        moneyText.text = "Money: " + money.ToString();
    }

    public bool RemoveMoney(int amount)
    {
        if (amount > money)
        {
            StartCoroutine(ShowWarning());
            return false;
        }
        else
        {
            money -= amount;
            moneyText.text = "Money: " + money.ToString();
            return true;
        }
    }

    IEnumerator ShowWarning()
    { 
        warningText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        warningText.gameObject.SetActive(false);
    }
}
