using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public Transform currentTarget;

    public Sprite towerSprite;

    [SerializeField]
    private int cost;

    [SerializeField]
    private float range;

    [SerializeField]
    private List<GameObject> targets = new List<GameObject>();

    public int GetCost()
    {
        return cost;
    }

    // Start is called before the first frame update
    void Start()
    {
        towerSprite = GetComponent<SpriteRenderer>().sprite;
        currentTarget = null;
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
    }

    GameObject SelectTarget()
    {
        GameObject currentTarget = null;

        if (targets != null)
        {
            currentTarget = targets[0];

            foreach (GameObject target in targets)
            {
                if (target.GetComponent<Enemy>().health < currentTarget.GetComponent<Enemy>().health)
                {
                    currentTarget = target;
                    Debug.Log("new target");
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

        return currentTarget;
    }

    IEnumerator ChangeTarget()
    {
        yield return new WaitForSeconds(0.1f);
        currentTarget = SelectTarget().transform;
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
