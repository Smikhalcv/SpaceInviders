using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _timeLife;
    private int _damage;
    public int Damage { get { return _damage; } set { _damage = value; } }


    private void Update()
    {
        Move();
        Destroy(gameObject, _timeLife);
    }

    private void Move()
    {
        transform.Translate(transform.forward * _speed);
    }
}
