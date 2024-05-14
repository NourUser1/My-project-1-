using UnityEngine;

public class LivesManager : MonoBehaviour
{
    public ScoreManager scoreManager;
    public int startingLives = 3; 
    private int currentLives;

    public UIManager uiManager;

    void Start()
    {
        InitializeLives();
    }

    void InitializeLives()
    {
        currentLives = startingLives;
        UpdateUI();
        scoreManager.InitializeScore();

    }

    public void LoseLife()
    {
        currentLives--;
        UpdateUI();

          if (currentLives <= 0)
        {
            GameManager.instance.PlayerDied();
            scoreManager.AddScore(currentLives * -100); 
        }
    }

    void UpdateUI()
    {
        if (uiManager != null)
        {
            uiManager.UpdateLifeCounter(currentLives);
        }
    }

    public void ResetLives()
    {
        currentLives = startingLives;
        UpdateUI();
    }
}
