using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OutputBestScore : MonoBehaviour
{
    [SerializeField] private Text _bestScore;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("BestScore"))
        {
            _bestScore.text = "The best score \n" + PlayerPrefs.GetInt("BestScore");
        }
    }
}
