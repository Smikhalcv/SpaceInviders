using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private float Speed = 5;
    [SerializeField] private int _damage;
    public int Damage { get { return _damage; } }
    [SerializeField] private float _timeLife;
    private Vector3 _direction;
    private Vector3 _target;
    public Vector3 Target { set { _target = value; } }

    private Rigidbody _bulletRig;

    private void Start()
    {
        transform.LookAt(_target);
        transform.rotation = Quaternion.Euler(-90, transform.rotation.eulerAngles.y, 0);
        _direction = (_target - transform.position).normalized;
        _bulletRig = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        MoveToTarget();
        _timeLife -= Time.deltaTime;
        if (_timeLife <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void MoveToTarget()
    {
        
        _bulletRig.AddForce(_direction * Speed, ForceMode.VelocityChange);
    }
}
