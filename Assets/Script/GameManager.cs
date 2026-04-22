using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerHealth player1;
    public PlayerHealth player2;

    bool isGameOver = false;

    void Update()
    {
        if (!isGameOver)
        {
            if (player1.hp <= 0 || player2.hp <= 0)
            {
                GameOver();
            }
        }
    }

    void GameOver()
    {
        isGameOver = true;
        Debug.Log("Game Over");

        Time.timeScale = 0;
    }
}