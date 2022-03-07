using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LIfePlayerShip : MonoBehaviour
{
    static private int _healthPoints = 1000;
    static public int HealthPoints { get { return _healthPoints; } set { _healthPoints = value; } }

    private AudioSource _soundTakeDamage;

    private void Start()
    {
        _soundTakeDamage = GetComponent<AudioSource>();
    }

    private void Update()
    {
        CheckCountLifePoint();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(collision.gameObject.GetComponent<LifeEnemy>().Damage);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            TakeDamage(collision.gameObject.GetComponent<EnemyBullet>().Damage);
            Destroy(collision.gameObject);
        }
    }

    private void TakeDamage(int damage)
    {
        _healthPoints -= damage;
        _soundTakeDamage.Play();
    }

    private void CheckCountLifePoint()
    {
        if (_healthPoints <= 0)
        {
            Destroy(gameObject);
        }
    }
}
