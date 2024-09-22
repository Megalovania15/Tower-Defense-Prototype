using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionRadius : MonoBehaviour
{
    private float explosionLifetime;

    private int damage;

    public List<Enemy> enemies = new List<Enemy>();

    public void SetExplosionRange(float _explosionRange)
    {
        transform.localScale = new Vector2(_explosionRange, _explosionRange);
        Debug.Log("Explosion radius updated");
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy") && !enemies.Contains(other.GetComponent<Enemy>()))
        {
            enemies.Add(other.GetComponent<Enemy>());

            foreach (Enemy enemy in enemies)
            { 
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
