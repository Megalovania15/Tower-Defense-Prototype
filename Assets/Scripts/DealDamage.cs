using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DealDamage : MonoBehaviour
{
    public int damageMin, damageMax;

    public GameObject damageTextPrefab;

    public TMP_Text damageText;

    public int DealRandomDamage()
    {
        int damageAmount = Random.Range(damageMin, damageMax);
        return damageAmount;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "MainTarget")
        {
            MainBuilding mainBuilding = other.gameObject.GetComponent<MainBuilding>();

            int damageAmount = DealRandomDamage();

            mainBuilding.TakeDamage(damageAmount);

            GameObject damageVisual = Instantiate(damageTextPrefab, transform.position, Quaternion.identity);

            print(damageVisual.transform.position);

            damageText = damageVisual.GetComponentInChildren<TextMeshPro>();

            damageText.text = damageAmount.ToString();

        }
    }
}
