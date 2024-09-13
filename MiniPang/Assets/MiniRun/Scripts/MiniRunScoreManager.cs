using UnityEngine;

public class MiniRunScoreManager : MonoBehaviour
{
    private int score = 0;

    public void IncreaseScore(int amount)
    {
        score += amount;
    }

    public int GetScore()
    {
        return score;
    }
}
