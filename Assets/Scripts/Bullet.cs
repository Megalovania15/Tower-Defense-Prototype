using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bullet : MonoBehaviour, IBullet
{
    public float bulletSpeed = 2f;
    public float bulletLifetime = 1f;

    [SerializeField]
    private int damageMin, damageMax;

    public GameObject damageTextPrefab;

    public TMP_Text damageText;

    private Rigidbody2D rb;

    /*public void SetDamage(int _damage)
    {
        damage = _damage; 
    }*/

    public void SetTarget(Vector3 position)
    {
        var lookPos = position - transform.position;

        float angle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle);

        rb = GetComponent<Rigidbody2D>();

        rb.velocity = transform.right * bulletSpeed;
    }

    // Start is called before the first frame update
    void Start()
    {
        
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

            int damageAmount = DealRandomDamage();

            //enemy takes damage
            enemyScript.TakeDamage(damageAmount);

            //destroys the bullet
            Destroy(gameObject);
        }
    }
}
