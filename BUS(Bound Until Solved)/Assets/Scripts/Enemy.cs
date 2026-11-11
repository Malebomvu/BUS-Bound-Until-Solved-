using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Health")]
    [SerializeField, Min(1f)]
    private float maxHealth = 100f;
    private float currentHealth;
    private bool isDead;

    [Header("Contact Damage")]
    [SerializeField, Min(0f)]
    private float contactDamage = 10f;

    [SerializeField, Min(0.05f)]
    private float damageInterval = 1f;
    private float nextDamageTime;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float amount)
    {

        if (isDead || amount <= 0f) return;
        currentHealth = Mathf.Max(currentHealth, amount);
        if (currentHealth <= 0f)
        {
            Die();
        }
      
    }

    private void OnTriggerStay(Collider other)
    {
        if (!isDead || Time.time < nextDamageTime) return;

        PlayerHealth player = other.GetComponentInParent<PlayerHealth>();
        if (player == null) return;

        player.TakeDamage(contactDamage);
        nextDamageTime = Time.time + damageInterval;
        
    }

    private void Die()
    {
        isDead = true;
        Destroy(gameObject);
    }
}


