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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            var enemyScript = other.gameObject.GetComponent<Enemy>();

            int damageAmount = Random.Range(damageMin, damageMax);

            GameObject damageVisual = Instantiate(damageTextPrefab, transform.position, Quaternion.identity);

            print(damageVisual.transform.position);

            damageText = damageVisual.GetComponentInChildren<TextMeshPro>();

            damageText.text = damageAmount.ToString();

            enemyScript.TakeDamage(damageAmount);

            Destroy(gameObject);
        }
    }
}
