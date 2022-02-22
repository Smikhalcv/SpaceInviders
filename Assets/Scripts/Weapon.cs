using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject _prefabBullet;
    private GameObject _bullet;
    [SerializeField] private float _timerToShot;
    private float _timer;

    private void Start()
    {
        _timer = _timerToShot;
    }

    // Update is called once per frame
    void Update()
    {
        _timer -= Time.deltaTime;
        if (_timer <= 0)
        {
            Shot();
            _timer = _timerToShot;
        }
    }

    private void Shot()
    {
        _bullet = Instantiate(_prefabBullet);
        _bullet.transform.position = transform.position;
    }

    public void BoostAttackSpeed(float boost)
    {
        _timerToShot *= boost;
        Debug.Log(_timerToShot);
    }
}
