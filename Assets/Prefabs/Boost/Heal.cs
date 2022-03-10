using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : Boosts
{
    [SerializeField] private int _recoveryHealth;
    private GameObject _player;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            IncreaseScore(collision.gameObject);
            _player.GetComponent<LifePlayerShip>().HealthPoints += _recoveryHealth;
            Destroy(gameObject);
        }
    }
}
