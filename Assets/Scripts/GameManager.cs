using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int ScorePlayer;
    private int _healthPlayer;
    public Text ScorePlayerText;
    public Text HealthPlayerText;

    private GameObject _player;

    private GameObject _createrEnemy;
    [SerializeField] private int _thresholdDifficulty;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _createrEnemy = GameObject.FindWithTag("EnemyCreater");
    }

    // Update is called once per frame
    void Update()
    {
        CheckHealthPlayer();
        UpdateScore();
        ImproveDifdiculytGame();
    }

    private void CheckHealthPlayer()
    {
        _healthPlayer = _player.gameObject.GetComponent<LIfePlayerShip>().HealthPoints;
        HealthPlayerText.text = _healthPlayer.ToString();
    }

    private void UpdateScore()
    {
        ScorePlayerText.text = "Score: " + ScorePlayer.ToString();
    }

    /// <summary>
    /// Увеличивает множитель хилпонтов врагов от количества набранных очков
    /// </summary>
    private void ImproveDifdiculytGame()
    {
        _createrEnemy.GetComponent<EnemyCreater>().ImproveHealthPoints = (int)Mathf.Round(ScorePlayer / _thresholdDifficulty) + 1;
    }
}
