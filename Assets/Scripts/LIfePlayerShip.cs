using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LIfePlayerShip : MonoBehaviour
{
    [SerializeField] private int _healthPoints;
    public int HealthPoints { get { return _healthPoints; } }

    private void Update()
    {
        CheckCountLifePoint();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(collision.gameObject.GetComponent<LifeEnemy>().Damage);
        }
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            TakeDamage(collision.gameObject.GetComponent<EnemyBullet>().Damage);
        }
        if (collision.gameObject.CompareTag("Heal"))
        {
            int _heal = collision.gameObject.GetComponent<Boosts>().Heal;
            Heal(_heal);
            Destroy(collision.gameObject);
        }
    }

    private void TakeDamage(int damage)
    {
        _healthPoints -= damage;
    }

    private void CheckCountLifePoint()
    {
        if (_healthPoints <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void Heal(int heal)
    {
        _healthPoints += heal;
    }
}
