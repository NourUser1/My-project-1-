using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int currentScore;

    void Start()
    {
        InitializeScore();
    }

    void InitializeScore()
    {
        currentScore = 0;
    }

    public void ResetScore()
    {
        InitializeScore();
    }

    public void AddScore(int scoreToAdd)
    {
        currentScore += scoreToAdd;
    }

    public void CalculateScore()
    {
        
        int livesRemaining = GameManager.instance.GetComponent<LivesManager>().GetCurrentLives();
        currentScore += livesRemaining * 100; 

    }


    public int GetCurrentScore()
    {
        return currentScore;
    }
}
