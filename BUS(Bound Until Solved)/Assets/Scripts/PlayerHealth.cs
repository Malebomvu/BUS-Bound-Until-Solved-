using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField, Min(1f)]
    public float maxHealth = 100f;
    private float currentHealth;
    private bool isDead;


    private void Awake()
    {
        currentHealth = maxHealth;
    }
   
    public void TakeDamage(float amaount)
    {
        if (isDead || amaount <= 0f) return;
        currentHealth = Mathf.Max(0f, currentHealth - amaount);
        Debug.Log($"Playerhealth: {currentHealth}/{maxHealth}", this);

        if (currentHealth <= 0f)
        {
            Die();
        }
    }
    private void Die()
    {
        isDead = true;
        Debug.Log("You died!", this);
    }
}
