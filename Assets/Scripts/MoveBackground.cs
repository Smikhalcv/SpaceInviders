using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    private Transform _pos;
    [SerializeField] private float _speed;
    private float _limitValue;
    private float _offset;

    private void Start()
    {
        _pos = GetComponent<Transform>();
        _limitValue = 2 * Camera.main.orthographicSize;
    }


    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        _offset += _speed * Time.fixedDeltaTime;
        _offset = Mathf.Repeat(_offset, _limitValue);
        _pos.position = new Vector3(0, 0, -_offset);        
    }
}
