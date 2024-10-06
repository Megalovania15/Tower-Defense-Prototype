using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEffect : MonoBehaviour, IStatusEffect
{
    //To add a status effect to the enemies when walking through or being hit by elemental explosions
    //or bullets

    private int damage;
    private float lifeTime;

    private Enemy currentEnemy;

    public void SetDamage(int _damage)
    {
        damage = _damage;
    }

    public void SetLifetime(float _lifetime)
    {
        lifeTime = _lifetime;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentEnemy = GetComponent<Enemy>();
        StartCoroutine(TakeDamageOverTime());
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(this, lifeTime);
    }

    IEnumerator TakeDamageOverTime()
    {
        while (true)
        {
            currentEnemy.TakeDamage(damage);
            yield return new WaitForSeconds(0.5f);
        }
    }

}
