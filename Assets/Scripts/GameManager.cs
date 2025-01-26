using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject enemyPrefab;  // Enemy prefab to spawn
    public Transform player;  // Player reference
    public Transform spawnArea;  // Area where enemies will spawn
    public int currentLevel = 1;  // Tracks current level
    public float arenaBoundaryY = -10f;  // Y position to check fall condition

    private int enemyCount;  // Tracks the number of enemies

    void Start()
    {
        StartLevel(currentLevel);
    }

    void Update()
    {
        CheckPlayerFall();
        CheckWinCondition();
    }

    void StartLevel(int level)
    {
        Debug.Log("Starting Level: " + level);
        enemyCount = level;  // Number of enemies increases with level

        // Spawn enemies based on current level
        for (int i = 0; i < enemyCount; i++)
        {
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        Vector3 spawnPosition = new Vector3(
            Random.Range(-5f, 5f),
            0.5f,  // Ensure it's above ground
            Random.Range(-5f, 5f)
        );

        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }

    void CheckPlayerFall()
    {
        if (player.position.y < arenaBoundaryY)
        {
            GameOver();
        }
    }

    void CheckWinCondition()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            LevelUp();
        }
    }

    void LevelUp()
    {
        currentLevel++;
        StartLevel(currentLevel);
    }

    void GameOver()
    {
        Debug.Log("Game Over! You fell off.");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);  // Restart game
    }
}
