using UnityEngine;

public class AttackSpeedBoost : Boosts
{
    [SerializeField] private float _boostAttackSpeed;
    private GameObject[] _weapons;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            IncreaseScore(collision.gameObject);
            _weapons = GameObject.FindGameObjectsWithTag("Weapon");
            for (int i = 0; i < _weapons.Length; i++)
            {
                _weapons[i].GetComponent<Weapon>().TimerToShot *= _boostAttackSpeed;
            }
            Destroy(gameObject);
        }
    }
}
