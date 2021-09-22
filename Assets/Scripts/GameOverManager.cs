using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public static GameOverManager Instance;
    
    public GameObject gameOverUI;

    public void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("More than one GameOver Instance");
            return;
        }

        Instance = this;
    }

    public void OnPlayerDeath()
    {
        if (CurrentSceneManager.Instance.isPlayerPresentByDefault)
        {
            DontDestroyOnLoadScene.Instance.RemoveFromDontDestroyOnLoad();
        }
        
        gameOverUI.SetActive(true);
    }

    public void RetryButton()
    {
        Inventory.Instance.RemoveCoins(CurrentSceneManager.Instance.coinsPickedUpInThisSceneCount);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        gameOverUI.SetActive(false);
        PlayerHealth.Instance.Respawn();
    }

    public void MainMenuButton()
    {
        DontDestroyOnLoadScene.Instance.RemoveFromDontDestroyOnLoad();
        SceneManager.LoadScene("MainMenu");
    }
    
    public void QuitButton()
    {
        Application.Quit();
    }
    
}
