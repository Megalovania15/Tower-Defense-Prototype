using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{
    public float speed;
    public int health = 30;
    public float distanceToAttack = 4f;

    public GameObject coinPrefab;
    public GameObject deathParticle;
    public GameObject damageTextPrefab;

    public Transform currentTarget; //keep track of the waypoint we're currently moving to
    public Transform mainTarget; //don't worry about this

    public Transform[] waypoints; //we have an array to keep track of our waypoints

    [SerializeField]
    private int moneyValue = 1;
    private int wpCount = 0; //keeping track of how many waypoints we've been to

    private Rigidbody2D rb; //if you move the enemy using physics
    private SpriteRenderer sprite;
    private MoneyTracker moneyTracker;

    private Color normalColour;
    private Color hitColour;
   
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        sprite = GetComponentInChildren<SpriteRenderer>();

        moneyTracker = FindObjectOfType<MoneyTracker>();

        mainTarget = GameObject.FindGameObjectWithTag("MainTarget").transform;

        //can automatically find the waypoints and define the array with them
        GameObject waypointCarrier = GameObject.Find("Waypoints");
        waypoints = waypointCarrier.GetComponentsInChildren<Transform>();

        //set the current waypoint target to the first element in the array
        currentTarget = waypoints[0];

        normalColour = sprite.color;
        hitColour = Color.white;

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
               
            }
        }
        else 
        {
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
            GameObject floatingCoin = Instantiate(coinPrefab, transform.position, Quaternion.identity);
            TMP_Text coinText = floatingCoin.GetComponentInChildren<TextMeshPro>();
            coinText.text = moneyValue.ToString();
            moneyTracker.CollectMoney(moneyValue);
            Instantiate(deathParticle, transform.position, Quaternion.identity);
            Destroy(floatingCoin,5.1f);
            Destroy(gameObject);
        }
    }

    //a method to take damage according to damage done, passed in as a parameter
    public void TakeDamage(int damageAmount)
    {
        //StartCoroutine(FlashWhite());
        //spawns the text game object to show the damage done
        GameObject damageVisual = Instantiate(damageTextPrefab, transform.position, Quaternion.identity);

        TMP_Text damageText = damageVisual.GetComponentInChildren<TextMeshPro>();

        //updates the text game object to show the amount of damage done
        damageText.text = damageAmount.ToString();
        health -= damageAmount;
    }

    IEnumerator FlashWhite()
    {
        sprite.color = hitColour;
        yield return new WaitForSeconds(0.1f);
        sprite.color = normalColour;
    }
}

