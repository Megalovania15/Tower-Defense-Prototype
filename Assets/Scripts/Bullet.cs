using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static UnityEngine.GraphicsBuffer;

public class Bullet : MonoBehaviour, IBullet
{
    public float bulletSpeed = 2f;
    public float rotationSpeed = 1f;
    public float bulletLifetime = 1f;

    [SerializeField]
    private int damageMin, damageMax;

    public GameObject damageTextPrefab;

    public TMP_Text damageText;

    private Rigidbody2D rb;

    private Transform target;

    /*public void SetDamage(int _damage)
    {
        damage = _damage; 
    }*/

    public void SetTarget(Transform _target)
    {
        target = _target;
    }

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

    void FixedUpdate()
    {
        if (target != null)
        {
            FollowTarget();
        }
    }

    void FollowTarget()
    {
        var lookPos = target.position - transform.position;

        lookPos.Normalize();

        float rotationValue = Vector3.Cross(lookPos, transform.right).z;

        rb.angularVelocity = -rotationValue * rotationSpeed;

        rb.velocity = transform.right * bulletSpeed;
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
