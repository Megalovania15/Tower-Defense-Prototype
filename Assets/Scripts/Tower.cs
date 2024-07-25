using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public Transform currentTarget;

    private List<GameObject> targets = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        currentTarget = null;
    }

    // Update is called once per frame
    void Update()
    {
        currentTarget = SelectTarget().transform;

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
                }
                else if (Vector3.Distance(transform.position, target.transform.position) <
                    Vector3.Distance(transform.position, currentTarget.transform.position))
                {
                    currentTarget = target;
                }

            }
        }

        return currentTarget;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy" && !targets.Contains(other.gameObject))
        {
            targets.Add(other.gameObject);
            //currentTarget = other.gameObject.transform;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            targets.Remove(other.gameObject);

            if (targets.Count == 0)
            {
                currentTarget = null;
            }
        }
    }
}
