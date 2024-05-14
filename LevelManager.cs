using UnityEngine;

public class LevelManager : MonoBehaviour
{
     public ScoreManager scoreManager;
    public Transform obstacleParent; 
    public GameObject obstaclePrefab; 

    private int currentLevel;
    private bool isLevelComplete;

    void Start()
    {
        InitializeLevel();
    }

    public void InitializeLevel()
    {
        currentLevel = 1;
        isLevelComplete = false;
        SetupLevel(currentLevel);
    }

    void SetupLevel(int level)
    {
        ClearObstacles();

        SpawnObstaclesForLevel(level);

    }

    void ClearObstacles()
    {
        foreach (Transform child in obstacleParent)
        {
            Destroy(child.gameObject);
        }
    }

    void SpawnObstaclesForLevel(int level)
    {
  
        for (int i = 0; i < 5; i++) 
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-5f, 5f), Random.Range(-3f, 3f), 0f); 
            Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity, obstacleParent);
        }
    }

    public void LevelComplete()
    {
        isLevelComplete = true;
        Debug.Log("Level Complete!");
        scoreManager.CalculateScore(); 
    }

    public void ResetLevel()
    {
        SetupLevel(currentLevel);
        isLevelComplete = false;
    }
}
