using System;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Inventory.Instance.AddCoins(1);
            CurrentSceneManager.Instance.coinsPickedUpInThisSceneCount++;
            Destroy(gameObject);
        }
    }
}
