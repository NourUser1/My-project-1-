using UnityEngine;
using UnityEngine.UI;

public class ClickHandler : MonoBehaviour
{
    private LivesManager livesManager;
    private LevelManager levelManager;
    private ScoreManager scoreManager;

    private void Awake()
    {
        livesManager = FindObjectOfType<LivesManager>();
        levelManager = FindObjectOfType<LevelManager>();
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    public void OnButtonClick()
    {
        livesManager.LoseLife();
        levelManager.ResetLevel();
        scoreManager.ResetScore();
    }
}