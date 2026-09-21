using System.Runtime.CompilerServices;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth = 80;
    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("You took damage, RUN! Current health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
        
    }
    private void Die()
    {
        Debug.Log("You died!");
    }
}
