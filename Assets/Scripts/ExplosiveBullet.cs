using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ExplosiveBullet : MonoBehaviour, IBullet
{
    public float bulletSpeed = 2f;
    public float bulletLifetime = 1f;

    [SerializeField]
    private int minDamage, maxDamage;

    [SerializeField]
    private float explosionRange;

    [SerializeField]
    private float explosionLifetime;

    public ElementTypes.Elements associatedElement;

    public ElementTypes elementTypesScript;

    public GameObject damageTextPrefab;
    public GameObject explosionRadiusPrefab;

    public TMP_Text damageText;

    private Rigidbody2D rb;

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
        elementTypesScript = FindObjectOfType<ElementTypes>();

        explosionRadiusPrefab = elementTypesScript.explosionRadii[(int)associatedElement];
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, bulletLifetime);
    }

    int DealRandomDamage()
    {
        int damageAmount = Random.Range(minDamage, maxDamage);

        return damageAmount;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            GameObject explosionRadiusObject = Instantiate(explosionRadiusPrefab, other.gameObject.transform.position, Quaternion.identity);

            //Debug.Log("Explosion created");

            ExplosionRadius explosionRadius = explosionRadiusObject.GetComponent<ExplosionRadius>();

            explosionRadius.SetExplosionRange(explosionRange);

            explosionRadius.SetExplosionLifetime(explosionLifetime);

            explosionRadius.SetDamage(DealRandomDamage());

            Destroy(gameObject);
        }
    }
}
