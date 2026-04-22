using UnityEngine;

public class HealSystem : MonoBehaviour
{
    public float healRange = 2f;
    public KeyCode healKey = KeyCode.E;
    public LayerMask playerLayer;

    void Update()
    {
        if (Input.GetKeyDown(healKey))
        {
            HealNearby();
        }
    }

    void HealNearby()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(
            transform.position,
            healRange,
            playerLayer
        );

        foreach (Collider2D hit in hits)
        {
            if (hit.gameObject == gameObject) continue;

            PlayerHealth friend = hit.GetComponent<PlayerHealth>();

            if (friend != null && friend.hp < friend.maxHP)
            {
                friend.Heal(1);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, healRange);
    }
}