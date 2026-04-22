using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private PlayerHealth health;

    void Start()
    {
        health = GetComponent<PlayerHealth>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Obstacle"))
        {
            health.TakeDamage(1);
        }
    }
}