using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boosts : MonoBehaviour
{   
    [SerializeField] protected private float _speed;
    [SerializeField] protected private float _boardPos;
    [SerializeField] protected private int _valueIncScore;


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

    protected private void IncreaseScore(GameObject player)
    {
        player.GetComponent<LifePlayerShip>().Score += _valueIncScore;
    }
}
