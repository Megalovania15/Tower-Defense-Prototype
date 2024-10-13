using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ExplosiveBullet : MonoBehaviour, IBullet
{
    public float bulletSpeed = 2f;
    public float rotationSpeed = 900f;
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

    private Transform target;

    private Rigidbody2D rb;

    public void SetTarget(Transform _target)
    {
        target = _target;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * bulletSpeed;

        elementTypesScript = FindObjectOfType<ElementTypes>();

        explosionRadiusPrefab = elementTypesScript.explosionRadii[(int)associatedElement];
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
