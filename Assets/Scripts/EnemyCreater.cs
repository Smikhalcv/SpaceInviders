using UnityEngine;

public class EnemyCreater : MonoBehaviour
{
    [SerializeField] private GameObject[] _shipsEnemy;
    [SerializeField] private float _timeToNewWave;
    private float _timerNewWave;
    [SerializeField] private float _countEnemyInWave;

    [SerializeField] static public int ImproveHealthPoints;

    private System.Random rnd;


    private void Start()
    {
        _timerNewWave = _timeToNewWave;
        Debug.Log(_shipsEnemy.Length);
        rnd = new System.Random();
    }

    // Update is called once per frame
    private void Update()
    {
        _timerNewWave -= Time.deltaTime;
        if (_timerNewWave <= 0)
        {
            CreateWaveEnemy();
            _timerNewWave = _timeToNewWave;
        }
    }

    private void CreateWaveEnemy()
    {
        for (int i = 0; i < _countEnemyInWave; i++)
        {
            GameObject shipEnemy = Instantiate<GameObject>(_shipsEnemy[rnd.Next(_shipsEnemy.Length)]);
            Vector3 shipPosition = transform.position;
            shipPosition.x = (float)(i * 10 - 25);
            shipEnemy.transform.position = shipPosition;
            shipEnemy.GetComponent<EnemyController>().IsShot = true;
            // задаёт время до первого выстрела
            int minTimeToShot = shipEnemy.GetComponent<EnemyController>().MinTimeToShot;
            int maxTimeToShot = shipEnemy.GetComponent<EnemyController>().MaxTimeToShot;
            shipEnemy.GetComponent<EnemyController>().TimerToShot = rnd.Next(minTimeToShot, maxTimeToShot);

            shipEnemy.GetComponent<LifeEnemy>().HeathPoints *= ImproveHealthPoints;
        }
    }

    private void CheckTimeToWave()
    {

    }
}
