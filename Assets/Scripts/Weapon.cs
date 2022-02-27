using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject _prefabBullet;
    private GameObject _bullet;
    [SerializeField] private float _timerToShot;
    private float _timer;
    private AudioSource _soundShotPlayer;

    private void Start()
    {
        _timer = _timerToShot;
        _soundShotPlayer = GetComponent<AudioSource>();
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
        _soundShotPlayer.Play();
    }

    public void BoostAttackSpeed(float boost)
    {
        _timerToShot *= boost;
        Debug.Log(_timerToShot);
    }
}
