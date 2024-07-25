using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 2f;
    public float bulletLifetime = 1f;
    public int damageMin, damageMax;

    public GameObject damageTextPrefab;

    public TMP_Text damageText;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.velocity = transform.right * bulletSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, bulletLifetime);
    }

    //calculates the amount of damage to deal between the damage range and returns the result
    int DealRandomDamage()
    {
        int damageAmount = Random.Range(damageMin, damageMax);

        return damageAmount;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            //gets the enemy script component
            var enemyScript = other.gameObject.GetComponent<Enemy>();

            //calculates the damage to be done on this collision
            int damageAmount = DealRandomDamage();

            //spawns the text game object to show the damage done
            GameObject damageVisual = Instantiate(damageTextPrefab, transform.position, Quaternion.identity);

            damageText = damageVisual.GetComponentInChildren<TextMeshPro>();

            //updates the text game object to show the amount of damage done
            damageText.text = damageAmount.ToString();

            //enemy takes damage
            enemyScript.TakeDamage(damageAmount);

            //destroys the bullet
            Destroy(gameObject);
        }
    }
}
