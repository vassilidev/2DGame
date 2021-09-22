using System;
using UnityEngine;
using UnityEngine.UI;

public class CurrentSceneManager : MonoBehaviour
{
    public static CurrentSceneManager Instance;

    public int coinsPickedUpInThisSceneCount;
    public bool isPlayerPresentByDefault = false;

    public Sprite background;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("More than one CurrentSceneManager Instance");
            return;
        }

        Instance = this;
    }

    public void Start()
    {
        if (background != null)
        {
            GameObject.FindWithTag("Background").GetComponent<Image>().sprite = background;
        }
    }
}