using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject _prefabBullet;
    private GameObject _bullet;
    static private float _timerToShot = 2f;
    static public float TimerToShot { get { return _timerToShot; } set { _timerToShot = value; } }
    private float _timer;
    private AudioSource _soundShotPlayer;

    private void Start()
    {
        _timer = _timerToShot;
        _soundShotPlayer = GetComponent<AudioSource>();
    }

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
        _soundShotPlayer.Play();
    }

    public void BoostAttackSpeed(float boost)
    {
        _timerToShot *= boost;
    }
}
