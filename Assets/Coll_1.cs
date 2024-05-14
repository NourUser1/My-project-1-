using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonResetLevel : MonoBehaviour
{
    public GameObject player; // Reference to the player object

    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(ResetLevel);
    }

    private void OnDestroy()
    {
        button.onClick.RemoveListener(ResetLevel);
    }

    private void ResetLevel()
    {
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
