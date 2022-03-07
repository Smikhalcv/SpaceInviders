using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : Boosts
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            LIfePlayerShip.HealthPoints += Heal;
            Destroy(gameObject);
        }
    }
}
