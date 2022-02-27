using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExplosion : MonoBehaviour
{
    private float _timeLife;
    private AudioSource _soundExplosion;


    private void Start()
    {
        _soundExplosion = GetComponent<AudioSource>();
        _timeLife = _soundExplosion.clip.length;
        _soundExplosion.Play();
        Debug.Log(_timeLife);

    }

    private void Update()
    {
        Destroy(gameObject, _timeLife);
    }
}
