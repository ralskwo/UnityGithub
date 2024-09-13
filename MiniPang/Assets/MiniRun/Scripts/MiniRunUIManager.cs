using TMPro;
using UnityEngine;

public class MiniRunUIManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public GameObject gameOverUI;

    public void UpdateScoreUI(int score)
    {
        scoreText.text = "Score: " + score;
    }

    public void ShowGameOverUI()
    {
        gameOverUI.SetActive(true);
    }

    public void HideGameOverUI()
    {
        gameOverUI.SetActive(false);
    }
}
