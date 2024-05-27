using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public delegate void LevelDelegate(int level);

     public ScoreManager scoreManager;
    public Transform obstacleParent; 

    // Code review : make this an array
    // array index <-> level index
    public GameObject obstaclePrefab; 

    private int currentLevel;
    private bool isLevelComplete;

    void Start()
    {
        InitializeLevel();
    }

    void InitializeLevel()
    {
        // Code review : first level will be index 0
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

            // access the prefab in the array at index "level"
            Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity, obstacleParent);
        }
    }

    public LevelDelegate OnDidCompleteLevel = null;
    public LevelDelegate OnDidResetLevel = null;

    public void LevelComplete()
    {
        isLevelComplete = true;
        Debug.Log("Level Complete!");
        OnDidCompleteLevel?.Invoke(currentLevel);

        scoreManager.CalculateScore();

        currentLevel++;

    }

    public void ResetLevel()
    {
        SetupLevel(currentLevel);
        isLevelComplete = false;

        OnDidResetLevel?.Invoke(currentLevel);
    }
}
