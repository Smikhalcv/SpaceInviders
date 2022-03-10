using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPowerBoost : Boosts
{
    [SerializeField] private int _boostAttackPower;
    private GameObject[] _weapons;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            IncreaseScore(collision.gameObject);
            _weapons = GameObject.FindGameObjectsWithTag("Weapon");
            for (int i = 0; i < _weapons.Length; i++)
            {
                _weapons[i].GetComponent<Weapon>().Damage += _boostAttackPower;
            }
            Destroy(gameObject);
        }
    }
}
