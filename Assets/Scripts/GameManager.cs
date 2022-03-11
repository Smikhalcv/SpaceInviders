using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Score Player")]
    private int _scorePlayer;
    private int _healthPlayer;
    public Text ScorePlayerText;
    public Text HealthPlayerText;
    public Text AttackPowerText;
    public Text AttackSpeedText;

    private GameObject _player;
    private GameObject _weapon;

    [Header("Setting Difficulty")]
    [SerializeField] private int _thresholdDifficulty;
    [SerializeField] private int _boostDifficulty;
    [SerializeField] private int _boostHealthPoint;

    [Header("GUI")]
    [SerializeField] private GameObject _finalMenu;
    [SerializeField] private GameObject _menu;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _weapon = GameObject.FindGameObjectWithTag("Weapon");
        Time.timeScale = 1;
    }

    private void Update()
    {
        GetScore();
        UpdateScore();
        UpdateAP();
        UpdateAS();
        ImproveDifdiculytGame();
        CheckHealthPlayer();
    }

    private void CheckHealthPlayer()
    {
        _healthPlayer = _player.GetComponent<LifePlayerShip>().HealthPoints;
        HealthPlayerText.text = _healthPlayer.ToString();
    }

    private void GetScore()
    {
        _scorePlayer = _player.GetComponent<LifePlayerShip>().Score;
    }

    private void UpdateScore()
    {
        ScorePlayerText.text = "Score: " + _scorePlayer.ToString();
    }

    private void UpdateAP()
    {
        AttackPowerText.text = _weapon.GetComponent<Weapon>().Damage.ToString();
    }

    private void UpdateAS()
    {
        AttackSpeedText.text = System.Math.Round(_weapon.GetComponent<Weapon>().TimerToShot, 2).ToString();

    }

    /// <summary>
    /// Увеличивает множитель хилпонтов врагов от количества набранных очков
    /// </summary>
    private void ImproveDifdiculytGame()
    {
        EnemyCreater.ImproveHealthPoints = 1 + (int)Mathf.Round(_scorePlayer / _thresholdDifficulty) +
            (int)Mathf.Round(_scorePlayer / _boostDifficulty) * _boostHealthPoint;
    }

    public void DeadPlayer()
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
            if (PlayerPrefs.GetInt("BestScore") < _scorePlayer)
            {
                PlayerPrefs.SetInt("BestScore", _scorePlayer);
            }
        }
        else PlayerPrefs.SetInt("BestScore", _scorePlayer);
    }
}
