using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public float invincibilityFlashDelay = 0.15f;
    public float invincibilityDelayAfterHit = 3f;
    
    public bool isInvincible = false;
    
    public SpriteRenderer graphics;
    public HealthBar healthBar;

    public static PlayerHealth Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("More than one instance of player health");
            return;
        }

        Instance = this;
    }

    void Start()
    {
        SetMaxHealth();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(80);
        }
    }

    public void SetMaxHealth()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damage)
    {
        if (!isInvincible)
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);

            if (!IsAlive())
            {
                Die();
                return;
            }
            
            isInvincible = true;
            StartCoroutine(InvincibilityFlash());
            StartCoroutine(HandleInvincibilityDelay());
        }
        
    }

    public bool IsAlive()
    {
        return (currentHealth > 0);
    }

    public void Die()
    {
        PlayerMovement.Instance.enabled = false;
        PlayerMovement.Instance.animator.SetTrigger("Die");
        PlayerMovement.Instance.rb.velocity = Vector3.zero; 
        PlayerMovement.Instance.rb.bodyType = RigidbodyType2D.Kinematic;
        PlayerMovement.Instance.playerCollider.enabled = false;
        GameOverManager.Instance.OnPlayerDeath();
    }
 
    public void Respawn()
    {
        PlayerMovement.Instance.enabled = true;
        PlayerMovement.Instance.animator.SetTrigger("Respawn");
        PlayerMovement.Instance.rb.bodyType = RigidbodyType2D.Dynamic;
        PlayerMovement.Instance.playerCollider.enabled = true;
        SetMaxHealth();
    } 

    public void HealPlayer(int amount)
    {
        if ((currentHealth + amount) > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else
        {
            currentHealth += amount;
        }
        healthBar.SetHealth(currentHealth);
    }

    public IEnumerator InvincibilityFlash()
    {
        while (isInvincible)
        {
            graphics.color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSeconds(invincibilityFlashDelay);
            graphics.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(invincibilityFlashDelay);
        }
    }

    public IEnumerator HandleInvincibilityDelay()
    {
        yield return new WaitForSeconds(invincibilityDelayAfterHit);
        isInvincible = false;
    }
}
