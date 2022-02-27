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

    private bool _deadPlayer = false;
    [SerializeField] private GameObject _finalMenu;
    [SerializeField] private GameObject _menu;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _createrEnemy = GameObject.FindWithTag("EnemyCreater");
        Time.timeScale = 1;
    }

    private void Update()
    {
        
        UpdateScore();
        ImproveDifdiculytGame();
        if (_deadPlayer)
        {
            DeadPlayer();
        }
        else
        {
            CheckHealthPlayer();
        }
    }

    private void CheckHealthPlayer()
    {
        _healthPlayer = _player.gameObject.GetComponent<LIfePlayerShip>().HealthPoints;
        HealthPlayerText.text = _healthPlayer.ToString();
        if (_healthPlayer <= 0)
        {
            _deadPlayer = true;
        }
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

    private void DeadPlayer()
    {
        Time.timeScale = 0;
        _finalMenu.SetActive(true);
        _menu.SetActive(false);
    }
}
