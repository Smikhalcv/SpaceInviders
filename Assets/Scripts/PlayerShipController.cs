using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerShipController : MonoBehaviour
{
    private float _boardOfDirectionController;
    [SerializeField] private float _speed;
    private float _rightBoard, _leftBoard;
    [SerializeField] private float _angleRotate;
    private Vector3 _pos;

    private Vector3 _rightPoint;
    private Vector3 _leftPoint;
    [SerializeField] private float _step;

    private GameObject[] _weapons;

    private GameObject _score;

    private void Start()
    {
        _boardOfDirectionController = Screen.width / 2;
        _rightBoard = Camera.main.orthographicSize * 0.4f;
        _leftBoard = Camera.main.orthographicSize * -0.4f;
        _rightPoint = transform.position;
        _rightPoint.x = _rightBoard;
        _leftPoint = transform.position;
        _leftPoint.x = _leftBoard;

        _weapons = GameObject.FindGameObjectsWithTag("Weapon");

        _score = GameObject.FindGameObjectWithTag("GameManager");
    }

    private void Update()
    {
        Move();        
    }

    private void Move()
    {
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).position.x > _boardOfDirectionController & transform.position.x < _rightBoard)
            {
                transform.position = Vector3.MoveTowards(transform.position, StepToRight(), _speed * Time.deltaTime);
                transform.rotation = Quaternion.Euler(0, 180, _angleRotate);
            }
            else if (Input.GetTouch(0).position.x < _boardOfDirectionController & transform.position.x > _leftBoard)
            {
                transform.position = Vector3.MoveTowards(transform.position, StepToLeft(), _speed * Time.deltaTime);
                transform.rotation = Quaternion.Euler(0, 180, -_angleRotate);
            }
        }
        else if (Input.GetKey(KeyCode.A) & transform.position.x > _leftBoard)
        {
            transform.position = Vector3.MoveTowards(transform.position, StepToLeft(), _speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, 180, -_angleRotate);
        }
        else if (Input.GetKey(KeyCode.D) & transform.position.x < _rightBoard)
        {
            transform.position = Vector3.MoveTowards(transform.position, StepToRight(), _speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, 180, _angleRotate);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("BoostAttackSpeed"))
        {
            for (int i = 0;  i < _weapons.Length; i++)
            {
                float boost = collision.gameObject.GetComponent<Boosts>().BoostAttackSpeed;
                _weapons[i].GetComponent<Weapon>().BoostAttackSpeed(boost);
            }
            _score.GetComponent<GameManager>().ScorePlayer += 100; 
            Destroy(collision.gameObject);
        }
    }

    private Vector3 StepToRight()
    {
        Vector3 rightPoint = transform.position;
        rightPoint.x += _step;
        return rightPoint;
    }

    private Vector3 StepToLeft()
    {
        Vector3 leftPoint = transform.position;
        leftPoint.x -= _step;
        return leftPoint;
    }
}
