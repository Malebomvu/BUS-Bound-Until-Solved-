using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    public float Damage = 10f;
    private Rigidbody rb;

    private void Awake()
    {
        rb= GetComponent<Rigidbody>();
    }

    public void PickUp(Transform holdPoint)
    {
        rb.useGravity = false;
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.SetParent(holdPoint);
        transform.localPosition = Vector3.zero;
    }

    public void Drop()
    {
        rb.useGravity=true;
        transform.SetParent(null);
    }

    public void MoveToHoldPoint(Vector3 targetPosition)
    {
        rb.MovePosition(targetPosition);
    }
    public void Throw(Vector3 impulse)
    {
        transform.SetParent(null);
        rb.useGravity = true;
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.AddForce(impulse, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Enemy enemyObject = collision.gameObject.GetComponent<Enemy>();
        if (enemyObject != null)
        {
            enemyObject.TakeDamage(Damage);
        }
    }

}
