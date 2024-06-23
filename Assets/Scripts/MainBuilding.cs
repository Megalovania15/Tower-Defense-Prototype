using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainBuilding : MonoBehaviour
{
    public int totalHealth = 50;

    public Slider healthBar;

    [SerializeField]
    private int currentHealth;

    private Color normalColour;
    private Color hitColour;

    private SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();

        normalColour = sprite.color;

        hitColour = Color.white;

        currentHealth = totalHealth;
    }

    // Update is called once per frame
    void Update()
    {
        Death();
    }

    void Death()
    { 
        if(currentHealth <= 0)
        {
            Destroy(gameObject);

        }
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        StartCoroutine("FlashWhite");
    }

    IEnumerator FlashWhite()
    {
        sprite.color = hitColour;
        yield return new WaitForSeconds(1f);
        sprite.color = normalColour;
    }

}
