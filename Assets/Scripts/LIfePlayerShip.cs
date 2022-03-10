using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePlayerShip : MonoBehaviour
{
    private int _healthPoints = 1000;
    public int HealthPoints { get { return _healthPoints; } set { _healthPoints = value; } }

    private AudioSource _soundTakeDamage;

    public int Score = 0;

    private GameManager _statusPlayer;

    private void Start()
    {
        _soundTakeDamage = GetComponent<AudioSource>();
        _statusPlayer = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        CheckCountLifePoint();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            Debug.Log("bullet");
            TakeDamage(collision.gameObject.GetComponent<EnemyBullet>().Damage);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("enemy");
            TakeDamage(collision.gameObject.GetComponent<LifeEnemy>().Damage);
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
            _statusPlayer.IsDead = true;
            Destroy(gameObject);
        }
    }
}
