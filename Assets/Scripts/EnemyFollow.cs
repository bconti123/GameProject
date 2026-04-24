using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform target;
    public float speed = 2f;

    void Update()
    {
        if (target == null) return;

        Vector2 direction = (target.position - transform.position).normalized;
        transform.position += (Vector3)(direction * speed * Time.deltaTime);
    }

    public void IncreaseSpeed(float amount)
    {
        speed += amount;
    }
}