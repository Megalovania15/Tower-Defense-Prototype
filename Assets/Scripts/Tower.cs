using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public Transform currentTarget;

    // Start is called before the first frame update
    void Start()
    {
        currentTarget = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTarget != null)
        {
            var lookPos = currentTarget.position - transform.position;

            float angle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            currentTarget = other.gameObject.transform;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            currentTarget = null;
        }
    }
}
