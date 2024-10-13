using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField]
    private float fireRate = 0.2f;

    [SerializeField]
    private float range;

    public Transform currentTarget;
    public Transform shootPoint;
    public GameObject bulletPrefab;
    
    private Tower towerScript;
    private float currentFireTime;

    [SerializeField]
    private List<GameObject> targets = new List<GameObject>();

    public float GetFireRate()
    {
        return fireRate;
    }

    // Start is called before the first frame update
    void Start()
    {
        towerScript = GetComponent<Tower>();

        currentTarget = null;

        currentFireTime = fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(ChangeTarget());

        if (currentTarget != null)
        {
            var lookPos = currentTarget.position - transform.position;

            float angle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(0, 0, angle);
        }

        currentFireTime -= Time.deltaTime;

        if (currentTarget != null && currentFireTime <= 0)
        {
            //creates the bullet
            GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, transform.rotation);
            //finds the script on the bullet so we can tell it what damage it should do
            IBullet bulletScript = bullet.GetComponent<IBullet>();

            bulletScript.SetTarget(currentTarget);
            //tells the bullet the damage it should do according to the tower's damage rate
            //bulletScript.SetDamage(DealRandomDamage());
            currentFireTime = fireRate;
        }
    }

    GameObject SelectTarget()
    {
        GameObject currentTarget = null;

        if (targets.Count != 0)
        {
            currentTarget = targets[0];

            foreach (GameObject target in targets)
            {
                if (target.GetComponent<Enemy>().health < currentTarget.GetComponent<Enemy>().health)
                {
                    currentTarget = target;
                    //Debug.Log("new target");
                    //Debug.Log(target.name + ", health: " + target.GetComponent<Enemy>().health);
                }
                /*else if (Vector3.Distance(transform.position, target.transform.position) < range)
                {
                    Debug.Log("new target");
                    currentTarget = target;
                    Debug.Log(target.name + ", distance: " + 
                        Vector3.Distance(transform.position, target.transform.position));
                }

                Debug.Log(target.name + ", distance: " +
                        Vector3.Distance(transform.position, target.transform.position));*/

            }
        }
        else
        {
            return currentTarget = null;
        }

        return currentTarget;
    }

    /*public int DealRandomDamage()
    {
        int damageDealt = Random.Range(damageMin, damageMax);
        return damageDealt;
    }*/

    IEnumerator ChangeTarget()
    {
        yield return new WaitForSeconds(0.1f);
        var newTarget = SelectTarget();
        if (newTarget != null)
        {
            currentTarget = newTarget.transform;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy") && !targets.Contains(other.gameObject))
        {
            targets.Add(other.gameObject);
            //currentTarget = other.gameObject.transform;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            targets.Remove(other.gameObject);

            if (targets.Count == 0)
            {
                currentTarget = null;
            }
        }
    }
}
