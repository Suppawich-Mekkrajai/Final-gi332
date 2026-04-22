using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHP = 2;
    public int hp;

    void Start()
    {
        hp = maxHP;
    }

    public void TakeDamage(int dmg = 1)
    {
        hp -= dmg;
        hp = Mathf.Clamp(hp, 0, maxHP);

        Debug.Log(name + " HP: " + hp);

        if (hp <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount = 1)
    {
        hp += amount;
        hp = Mathf.Clamp(hp, 0, maxHP);

        Debug.Log(name + " Heal → HP: " + hp);
    }

    void Die()
    {
        Debug.Log(name + " Died");
        gameObject.SetActive(false);
    }
}