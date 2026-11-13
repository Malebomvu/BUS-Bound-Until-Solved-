using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth = 100;
    public HUDManager hud;

    private void Start()
    {
        currentHealth = maxHealth;
       
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log("Player took damage! Current health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
        if (currentHealth < 0)
            currentHealth = 0;
        hud.SetHealth(currentHealth, maxHealth);
    }

    private void Die()
    {
        Debug.Log("Player has died!");
        // Add respawn, game over, or animation here
    }
}

