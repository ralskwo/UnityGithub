using UnityEngine;

public class MiniRunObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float spawnInterval = 2f;
    private bool isSpawning = false;

    void Update()
    {
        if (isSpawning)
        {
            spawnInterval -= Time.deltaTime;
            if (spawnInterval <= 0)
            {
                SpawnObstacle();
                spawnInterval = 2f;
            }
        }
    }

    public void StartSpawning()
    {
        isSpawning = true;
    }

    public void StopSpawning()
    {
        isSpawning = false;
    }

    private void SpawnObstacle()
    {
        Instantiate(obstaclePrefab, new Vector3(10, Random.Range(-2f, 2f), 0), Quaternion.identity); // Z축은 0으로 고정
    }
}
