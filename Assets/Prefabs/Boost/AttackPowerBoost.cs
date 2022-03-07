using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPowerBoost : Boosts
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Bullet.Damage += BoostAttackPower;
            Destroy(gameObject);
        }    
    }
}
