using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float _timeToMoveDown;
    private float _timerDown;
    private Vector3 _target;
    private float _rightBoard, _leftBoard;
    [SerializeField] private float _stepMoveAside;
    [SerializeField] private float _speedMoveAside;
    [SerializeField] private float _stepMoveDown;
    private float _coorZ;

    private GameObject _player;
    
    public bool IsShot;
    private float _timerToShot;
    public float TimerToShot { set { _timerToShot = value; } }
    [SerializeField] private int _minTimeToShot;
    public int MinTimeToShot { get { return _minTimeToShot; } }
    [SerializeField] private int _maxTimeToShot;
    public int MaxTimeToShot { get { return _maxTimeToShot; } }
    [SerializeField] private GameObject _enemyBullet;
    [SerializeField] private int _chanceShooting;


    private void Start()
    {
        _rightBoard = transform.position.x + _stepMoveAside;
        _leftBoard = transform.position.x - _stepMoveAside;
        _target = transform.position;
        _target.x = _leftBoard;
        _coorZ = transform.position.z;
        _timerDown = _timeToMoveDown;

        _player = GameObject.FindGameObjectWithTag("Player");

    }


    private void Update()
    {
        Move();
        CheckDirectionMove();
        CheckTimeToMoveDown();

        CheckGoOutDisplay();

        if (IsShot)
        {
            _timerToShot -= Time.deltaTime;
            if (_timerToShot <= 0)
            {
                Shot();
            }
        }
    }

    private void CheckDirectionMove()
    {
        if (_leftBoard >= transform.position.x)
        {
            _target = transform.position;
            _target.x = _rightBoard;
            _target.z = _coorZ;
        }
        else if (_rightBoard <= transform.position.x)
        {
            _target = transform.position;
            _target.x = _leftBoard;
            _target.z = _coorZ;
        }
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target, _speedMoveAside * Time.deltaTime);
    }

    private void CheckTimeToMoveDown()
    {
        _timerDown -= Time.deltaTime;
        if (_timerDown <= 0)
        {
            _coorZ -= _stepMoveDown;
            _timerDown = _timeToMoveDown;
        }
    }

    private void Shot()
    {
        GameObject bullet = Instantiate<GameObject>(_enemyBullet);
        bullet.transform.position = transform.position;
        bullet.GetComponent<EnemyBullet>().Target = _player.transform.position;
        System.Random _rnd = new System.Random();
        _timerToShot = _rnd.Next(_minTimeToShot, _maxTimeToShot);
        Debug.Log(_timerToShot);
    }

    private void CheckGoOutDisplay()
    {
        if (transform.position.y <= -110)
        {
            Destroy(gameObject);
        }
    }
}
