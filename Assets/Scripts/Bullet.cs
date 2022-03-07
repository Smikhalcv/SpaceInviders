using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _timeLife;
    static private int _damage = 100;
    static public int Damage { get { return _damage; } set { _damage = value; } }


    private void Update()
    {
        Move();
        Destroy(gameObject, _timeLife);
    }

    private void Move()
    {
        transform.Translate(transform.forward * _speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

}
