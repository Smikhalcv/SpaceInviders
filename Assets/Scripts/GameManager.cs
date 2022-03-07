using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Score Player")] 
    public int ScorePlayer;
    private int _healthPlayer;
    public Text ScorePlayerText;
    public Text HealthPlayerText;

    private GameObject _player;

    [Header("Setting Difficulty")]
    [SerializeField] private int _thresholdDifficulty;
    [SerializeField] private int _boostDifficulty;
    [SerializeField] private int _boostHealthPoint;

    
    private bool _deadPlayer = false;
    [Header("GUI")]
    [SerializeField] private GameObject _finalMenu;
    [SerializeField] private GameObject _menu;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
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
        _healthPlayer = LIfePlayerShip.HealthPoints;
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
        EnemyCreater.ImproveHealthPoints = 1 + (int)Mathf.Round(ScorePlayer / _thresholdDifficulty) +
            (int)Mathf.Round(ScorePlayer / _boostDifficulty) * _boostHealthPoint;
    }

    private void DeadPlayer()
    {
        SaveBestScore();
        Time.timeScale = 0;
        _finalMenu.SetActive(true);
        _menu.SetActive(false);        
    }

    private void SaveBestScore()
    {
        if (PlayerPrefs.HasKey("BestScore"))
        {
            if (PlayerPrefs.GetInt("BestScore") < ScorePlayer)
            {
                PlayerPrefs.SetInt("BestScore", ScorePlayer);
            }
        }
        else PlayerPrefs.SetInt("BestScore", ScorePlayer);


    }
}
