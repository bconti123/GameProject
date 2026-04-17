using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform target;
    public float speed = 3f;

    public float detectRadius = 6f;
    public float stopDistance = 0.8f;
    
    public float normalSpeed = 2.5f;
    public float sprintSpeed = 4.5f;
    public float sprintDistance = 2f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (target == null)
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }

        float distance = Vector2.Distance(rb.position, target.position);
        // TOO FAR: DO NOTHING
        if (distance > detectRadius)
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }

        // VERY CLOSE: Stop so it doesn't jitter badly
        if (distance <= stopDistance)
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }

        Vector2 direction = ((Vector2)target.position - rb.position).normalized;

        float currentSpeed = normalSpeed;
        if (distance <= sprintDistance)
        {
            currentSpeed = sprintSpeed;
        }

        rb.linearVelocity = direction * currentSpeed;
    }
}