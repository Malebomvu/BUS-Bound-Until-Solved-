using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public float lookRadius = 40f;
    public Transform Player;
    public int damage = 10;
    public float attackCooldown = 2f;
    private float lastAttackTime;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        if (Player == null)
        {
            Debug.LogError("No GameObject with tag 'Player' found at Start!");
        }
        else
        {
            Player = transform;
        }

    }

    private void Update()
    {
        float distance = Vector3.Distance(Player.position, transform.position);

        if (distance <= lookRadius)
        {
            agent.SetDestination(Player.position);
        }
    }

    private void AttackPlayer()
    {
        if (Time.time - lastAttackTime >= attackCooldown)
        {
            Player playerHealth = Player.GetComponent<Player>();
            {
                playerHealth.TakeDamage(damage);
            }
            lastAttackTime = Time.time;

        }
    }
        
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.purple;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}


