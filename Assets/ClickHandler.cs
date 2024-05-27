using UnityEngine;
using UnityEngine.UI;

public class ClickHandler : MonoBehaviour
{

    [SerializeField] private InputManager inputManager = null;

    private LivesManager livesManager;
    private LevelManager levelManager;
    private ScoreManager scoreManager;


    private void Awake()
    {
        livesManager = FindObjectOfType<LivesManager>();
        levelManager = FindObjectOfType<LevelManager>();
        scoreManager = FindObjectOfType<ScoreManager>();

        inputManager.OnCliked += OnButtonClick;
    }

    public void OnButtonClick(GameObject i_go)
    {
        StickyNote note = i_go.GetComponent<StickyNote>();

        if(note.IsFailureNote) 
        {
            livesManager.LoseLife();
            levelManager.ResetLevel();
            scoreManager.ResetScore();
        }
        else
        {
            // sucess stuff
        }


    }
}