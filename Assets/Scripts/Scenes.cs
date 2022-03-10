using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    public void ChangeScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

    public void Restart()
    {
        Debug.Log(SceneManager.sceneCount);
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Continue(GameObject menu)
    {
        Time.timeScale = 1;
        menu.SetActive(false);
    }

    public void InvokeMenu(GameObject menu)
    {
        Time.timeScale = 0;
        menu.SetActive(true);
    }

}
