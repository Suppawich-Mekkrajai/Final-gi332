using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image fillImage;
    public PlayerHealth playerHealth;

    void Update()
    {
        if (playerHealth == null) return;

        float hpPercent = (float)playerHealth.hp / playerHealth.maxHP;
        fillImage.fillAmount = hpPercent;

        // เปลี่ยนสี
        if (hpPercent > 0.5f)
            fillImage.color = Color.green;
        else if (hpPercent > 0.2f)
            fillImage.color = Color.yellow;
        else
            fillImage.color = Color.red;
    }
}