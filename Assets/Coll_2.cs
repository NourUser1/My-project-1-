using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonResetLevel_1 : MonoBehaviour
{
    public GameObject player; // Reference to the player object

    private Button button_1;

    private void Start()
    {
        button_1 = GetComponent<Button>();
        button_1.onClick.AddListener(ResetLevel);
    }

    private void OnDestroy()
    {
        button_1.onClick.RemoveListener(ResetLevel);
    }

    private void ResetLevel()
    {
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
