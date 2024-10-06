using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionRadius : MonoBehaviour
{
    public StatusEffect.Type associatedEffect;

    public List<Enemy> enemies = new List<Enemy>();

    private float explosionLifetime;

    [SerializeField]
    private float statusEffectLifetime;

    private int damage;

    public void SetExplosionRange(float _explosionRange)
    {
        transform.localScale = new Vector2(_explosionRange, _explosionRange);
        //Debug.Log("Explosion radius updated");
    }

    public void SetExplosionLifetime(float _explosionLifetime)
    {
        explosionLifetime = _explosionLifetime;
    }

    public void SetDamage(int _damage)
    {
        damage = _damage;
    }


    void Update()
    {
        Destroy(gameObject, explosionLifetime);
    }

    public void ApplyElementalEffect(GameObject objectInRadius, System.Type associatedEffect)
    {
        IStatusEffect statusEffect = (IStatusEffect)objectInRadius.AddComponent(associatedEffect);

        statusEffect.SetDamage(1);
        statusEffect.SetLifetime(statusEffectLifetime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy") && !enemies.Contains(other.GetComponent<Enemy>()))
        {
            enemies.Add(other.GetComponent<Enemy>());

            foreach (Enemy enemy in enemies)
            {
                System.Type effectType = StatusEffect.GetStatusEffect(associatedEffect);

                Component component;

                if (associatedEffect != StatusEffect.Type.None && !enemy.gameObject.TryGetComponent(effectType, out component))
                {
                    ApplyElementalEffect(enemy.gameObject, effectType);
                    Debug.Log("Effect has been added");
                }
                enemy.TakeDamage(damage);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            enemies.Remove(other.GetComponent<Enemy>());
        }
    }
}
