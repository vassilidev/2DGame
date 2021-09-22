using System;
using UnityEngine;

public class HealPowerUp : MonoBehaviour
{
    public int healAmount = 20;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (PlayerHealth.Instance.currentHealth < PlayerHealth.Instance.maxHealth)
            {
                PlayerHealth.Instance.HealPlayer(healAmount);
                Destroy(gameObject);
            }
        }
    }
}
