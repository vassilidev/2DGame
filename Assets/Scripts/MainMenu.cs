using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string levelToLoad;

    public GameObject settingsWindows;

    public static MainMenu Instance;

    public void Awake()
    {
        if (Instance != null)
        {
            return;
        }

        Instance = this;
    }

    public void StartGameButton()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void SettingsButton()
    {
        settingsWindows.SetActive(true);
    }

    public void MainMenuButton()
    {
        settingsWindows.SetActive(false);
    }

    public void QuitGameButton()
    {
        Application.Quit();
    }
}
