using System;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public int coinsCount;
    public Text coinsCountText;
    
    public static Inventory Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("More than one instance of inventory");
            return;
        }
        
        Instance = this;
    }

    public void SetCoinsText()
    {
        coinsCountText.text = coinsCount.ToString();
    }

    public void AddCoins(int amount)
    {
        coinsCount += amount;
        SetCoinsText();
    }
    
    public void RemoveCoins(int amount)
    {
        coinsCount -= amount;
        SetCoinsText();
    }

    public void ResetCoins()
    {
        coinsCount = 0;
        SetCoinsText();
    }
}
