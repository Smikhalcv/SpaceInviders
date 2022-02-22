using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boosts : MonoBehaviour
{
    public float BoostAttackSpeed = 0.95f;
    public int Heal = 100;
    [SerializeField] private float _speed;
    [SerializeField] private float _boardPos;

    private void Update()
    {
        transform.Translate(transform.forward * -_speed * Time.deltaTime);
        CheckPosition();
    }

    private void CheckPosition()
    {
        if (transform.position.z <= _boardPos)
        {
            Destroy(gameObject);
        }
    }
}
