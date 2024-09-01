using UnityEngine;
using TMPro;

public class MiniPangScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private MiniPangScoreUpdater scoreUpdater;

    void Start()
    {
        scoreUpdater = new MiniPangScoreUpdater(scoreText);

        var boardManager = this.GetComponent<MiniPangBoardManager>();
        boardManager.SetScoreUpdater(scoreUpdater);

        scoreUpdater.AddScore(0);  // 초기 점수 설정
    }
}
