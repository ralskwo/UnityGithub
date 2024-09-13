using TMPro;

public class MiniPangScoreUpdater
{
    private int score = 0;
    private TextMeshProUGUI scoreText;

    public MiniPangScoreUpdater(TextMeshProUGUI _scoreText)
    {
        scoreText = _scoreText;
    }

    // ��Ī�� Ÿ�� ���� �޾Ƽ� ������ ����ϰ� ������Ʈ�ϴ� �޼���
    public void OnTilesDestroyed(int matchedTileCount)
    {
        int points = CalculateScore(matchedTileCount);
        AddScore(points);
    }

    // ���� ��� ������ �����ϴ� �޼���
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
        return 0; // ��Ī�� 3�� �̸��� ��� ���� ����
    }

    // ������ �߰��ϰ� UI�� ������Ʈ�ϴ� �޼���
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
