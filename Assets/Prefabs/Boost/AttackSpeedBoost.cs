using UnityEngine;

public class AttackSpeedBoost : Boosts
{
     private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Weapon.TimerToShot *= BoostAttackSpeed;
            Destroy(gameObject);
        }
    }
}
