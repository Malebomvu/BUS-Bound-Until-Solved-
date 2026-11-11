using UnityEngine;
using UnityEngine.AI;

public class PickUpObject : MonoBehaviour
{
    [Header("Thrown")]
    [SerializeField, Min(0f)]
    private Transform player;
    public float damage = 10f;
    private Rigidbody rb;
    private bool canDamageEnemy;


    private void Awake()
    {
        rb= GetComponent<Rigidbody>();
    }

    public void PickUp(Transform holdPoint)
    {
        canDamageEnemy= false;
        rb.useGravity = false;
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.SetParent(holdPoint);
        transform.localPosition = Vector3.zero;
       transform.localRotation =  Quaternion.identity; 
    }

    public void Drop()
    {
        rb.useGravity=true;
        transform.SetParent(null);
        rb.isKinematic = false;
        rb.useGravity = true;
        canDamageEnemy = false;
    }

    public void MoveToHoldPoint(Vector3 targetPosition)
    {
        if(rb.isKinematic)
        rb.MovePosition(targetPosition);
    }
    public void Throw(Vector3 impulse)
    {
        transform.SetParent(null, true);
        rb.isKinematic = false;
        rb.useGravity = true;
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        canDamageEnemy = true;
        rb.AddForce(impulse, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        TryDamageEnemy(collision.collider);
    }

    private void TryDamageEnemy(Collider other)
    {
        if (!canDamageEnemy) return;
        Enemy enemy = other.gameObject.GetComponent<Enemy>();
        if (enemy == null) return;
        enemy.TakeDamage(damage);

        canDamageEnemy=false;
    }

}
