using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public float fireRate = 0.2f;

    public Transform shootPoint;
    public GameObject bulletPrefab;
    
    private Tower towerScript;
    private float currentFireTime;

    // Start is called before the first frame update
    void Start()
    {
        towerScript = GetComponent<Tower>();

        currentFireTime = fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        currentFireTime -= Time.deltaTime;

        if (towerScript.currentTarget != null && currentFireTime <= 0)
        {
            GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, transform.rotation);
            currentFireTime = fireRate;
        }
    }
}
