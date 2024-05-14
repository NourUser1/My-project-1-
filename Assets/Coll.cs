using UnityEngine;

public class PlayerCollideAndActivateButtons : MonoBehaviour
{
    public GameObject buttonPrefab; // Reference to the button prefab
    public Transform canvasParent; // Parent transform for the buttons
    public GameObject hiddenObject; // Reference to the hidden object

    private bool buttonsActivated = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == hiddenObject && !buttonsActivated)
        {
            buttonsActivated = true;
            ActivateButtons();
        }
    }

    private void ActivateButtons()
    {
        // Instantiate and position buttons in the canvas
        for (int i = 1; i <= 3; i++)
        {
            GameObject button = Instantiate(buttonPrefab, canvasParent);
            button.transform.localPosition = new Vector3(i * 100, 100, 0); // Adjust position as needed
            button.SetActive(true); // Show buttons
            if (i == 1)
            {
                // Modify Button 1 to destroy the hidden object (Correct Choice)
                button.GetComponent<ButtonDestroyHiddenObject>().hiddenObject = hiddenObject;
            }
            else
            {
                // Modify Button 2 and Button 3 to reset the level (Wrong Choices)
                button.GetComponent<ButtonResetLevel>().player = gameObject;
            }
        }
    }
}
