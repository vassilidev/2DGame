using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyOnLoadScene : MonoBehaviour
{
    public static DontDestroyOnLoadScene Instance;
    
    public GameObject[] objects;
    
    private void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("More than one Instance of DontDestroyOnLoadScene");
            return;
        }

        Instance = this;
        
        foreach (var element in objects)
        {
            DontDestroyOnLoad(element);
        }
    }

    public void RemoveFromDontDestroyOnLoad()
    {
        foreach (var element in objects)
        {
            SceneManager.MoveGameObjectToScene(element, SceneManager.GetActiveScene());
        }
    }
}
