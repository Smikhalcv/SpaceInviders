using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeEnemy : MonoBehaviour
{
    [SerializeField] private int _healthPoints;
    public int HeathPoints { get { return _healthPoints; } set { _healthPoints = value; } }
    [SerializeField] private GameObject[] _boosts;
    [SerializeField] private float _chanceDropBooster;
    [SerializeField] private int _damage;
    public int Damage { get { return _damage; } }

    private GameObject _score;

    [SerializeField] private GameObject _soundExplosion;

    private void Start()
    {
        _score = GameObject.FindGameObjectWithTag("GameManager");
    }

    void Update()
    {
        CheckLifePoint();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            TakeDamage(Bullet.Damage);
            Destroy(collision.gameObject);
        }
    }

    private void CheckLifePoint()
    {
        if (_healthPoints <= 0)
        {
            _score.GetComponent<GameManager>().ScorePlayer += 100;
            DropBooster();

            GameObject explosion = Instantiate<GameObject>(_soundExplosion);
            explosion.transform.position = transform.position;

            Destroy(gameObject);
        }
    }

    private void DropBooster()
    {
        System.Random _rnd = new System.Random();
        if (_rnd.Next(100) < _chanceDropBooster)
        {
            GameObject booster = Instantiate<GameObject>(_boosts[_rnd.Next(_boosts.Length)]);
            booster.transform.position = transform.position;
            booster.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    private void TakeDamage(int damege)
    {
        _healthPoints -= damege;
    }
}
