using UnityEngine;

public class StickyNoteCollision : MonoBehaviour
{
    public GameObject button;      // Reference to the "Button" GameObject
    public GameObject button1;     // Reference to the "Button (1)" GameObject
    public GameObject button2;     // Reference to the "Button (2)" GameObject

    private void Start()
    {
        // Initially make sticky notes invisible
        button.SetActive(false);    // Ensure "Button" is assigned in the Inspector and make it initially invisible
        button1.SetActive(false);   // Ensure "Button (1)" is assigned in the Inspector and make it initially invisible
        button2.SetActive(false);   // Ensure "Button (2)" is assigned in the Inspector and make it initially invisible
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Ensure your stick-man character has the tag "Player"
        {
            // Make sticky notes visible
            button.SetActive(true);     // Make "Button" appear
            button1.SetActive(true);    // Make "Button (1)" appear
            button2.SetActive(true);    // Make "Button (2)" appear
        }
    }
}
