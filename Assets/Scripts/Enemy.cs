using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public int health = 30;
    public float distanceToAttack = 4f;

    public Transform currentTarget; //keep track of the waypoint we're currently moving to
    public Transform mainTarget; //don't worry about this

    public Transform[] waypoints; //we have an array to keep track of our waypoints

    [SerializeField]
    private int minCoin, maxCoin;

    private Rigidbody2D rb; //if you move the enemy using physics
    private Animator anim; //don't worry about this
    private MoneyTracker moneyTracker;
   
    private int wpCount = 0; //keeping track of how many waypoints we've been to

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();
        //anim.enabled = false;

        moneyTracker = FindObjectOfType<MoneyTracker>();

        mainTarget = GameObject.FindGameObjectWithTag("MainTarget").transform;

        //can automatically find the waypoints and define the array with them
        GameObject waypointCarrier = GameObject.Find("Waypoints");
        waypoints = waypointCarrier.GetComponentsInChildren<Transform>();

        //set the current waypoint target to the first element in the array
        currentTarget = waypoints[0];

        anim.SetBool("isAttacking", false);

    }

    // Update is called once per frame
    void Update()
    {

        if (currentTarget != null)
        {
            //check to see if we've gone through all of the waypoints
            if (wpCount < waypoints.Length)
            {
                //setting the current waypoint to the next one
                currentTarget = waypoints[wpCount];

                Move();

                //check if the distance to the current waypoint target is a certain amount
                //increase the waypoint count so we start moving towards the next waypoint
                if (Vector3.Distance(transform.position, currentTarget.position) <= 0.5f)
                {
                    wpCount++;
                }
            }
            else
            {
                currentTarget = mainTarget;

                Move();

                Debug.Log(Vector2.Distance(currentTarget.position, gameObject.transform.position));

                if (Vector2.Distance(currentTarget.position, gameObject.transform.position) <= distanceToAttack)
                {
                    Debug.Log("Building under attack");

                    rb.velocity = Vector2.zero;

                    anim.SetBool("isAttacking", true);

                    //anim.enabled = true;
                }
               
            }
        }
        else 
        {
            //anim.enabled = false;

            anim.SetBool("isAttacking", false);

            rb.velocity = Vector2.zero;
        }
        
        Death();
    }

    void Move()
    {
        //need to find the direction of the current waypoint by finding the difference
        //between the current position vector and the waypoint vector
		var moveDir = currentTarget.position - transform.position;

        //can find the angle that we're facing using Mathf.Atan2
        //can otherwise just use Vector2.MoveTowards
		float angle = Mathf.Atan2(moveDir.y, moveDir.x) * Mathf.Rad2Deg;

        //update the rotation
		transform.rotation = Quaternion.Euler(0, 0, angle);

        //float step = speed * Time.deltaTime;

        //transform.position = Vector2.MoveTowards(transform.position, currentTarget.position, step);
        
        //move the enemy using physics
		rb.velocity = transform.right * speed;

    }

    void Death()
    {
        if (health <= 0)
        {
            moneyTracker.CollectMoney(minCoin, maxCoin);
            Destroy(gameObject);
        }
    }

    //a method to take damage according to damage done, passed in as a parameter
    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
    }

   
}

