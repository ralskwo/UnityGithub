using UnityEngine;

public class MiniRunGameManager : MonoBehaviour
{
    public MiniRunPlayerController playerController;
    public MiniRunObstacleSpawner obstacleSpawner;
    public MiniRunScoreManager scoreManager;
    public MiniRunUIManager uiManager;

    private bool isGameRunning = false;

    private void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        isGameRunning = true;
        playerController.StartRunning();
        obstacleSpawner.StartSpawning();
    }

    public void PauseGame()
    {
        isGameRunning = false;
        Time.timeScale = 0f;
    }

    public void EndGame()
    {
        isGameRunning = false;
        playerController.StopRunning();
        obstacleSpawner.StopSpawning();
        uiManager.ShowGameOverUI();
    }
}
