using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnSound : MonoBehaviour
{
    private bool _status = true;
    private Button _button;

    private void Start()
    {
        _button = GetComponent<Button>();

        if (_status == false)
        {
            _button.GetComponentInChildren<Text>().text = "Sound off";
        }
        else
        {
            _button.GetComponentInChildren<Text>().text = "Sound on";
        }
    }

    public void ActiveSound(Button button)
    {
        if (_status == true)
        {
            _status = false;
            AudioListener.volume = 0;
            button.GetComponentInChildren<Text>().text = "Sound off";
        }
        else
        {
            _status = true;
            AudioListener.volume = 1;
            button.GetComponentInChildren<Text>().text = "Sound on";
        }
    }
}
