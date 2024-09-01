using TMPro;

public class MiniPangScoreUpdater
{
    private int score = 0;
    private TextMeshProUGUI scoreText;

    public MiniPangScoreUpdater(TextMeshProUGUI _scoreText)
    {
        scoreText = _scoreText;
    }

    // 매칭된 타일 수를 받아서 점수를 계산하고 업데이트하는 메서드
    public void OnTilesDestroyed(int matchedTileCount)
    {
        int points = CalculateScore(matchedTileCount);
        AddScore(points);
    }

    // 점수 계산 로직을 포함하는 메서드
    private int CalculateScore(int blockCount)
    {
        if (blockCount == 3)
        {
            return blockCount * 5;
        }
        else if (blockCount >= 4)
        {
            return blockCount * 7;
        }
        return 0; // 매칭이 3개 미만일 경우 점수 없음
    }

    // 점수를 추가하고 UI를 업데이트하는 메서드
    public void AddScore(int points)
    {
        score += points;
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score;
    }
}
