using TMPro;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI scoreText;

    public void UpdateHealth(int health)
    {
        healthText.text = "Health: " + health.ToString();
    }

    public void UpdateScore(int score)
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
