using UnityEngine;

public class HiddenBoxController : MonoBehaviour
{
    public GameObject player;
    public GameObject textBars;
    public string correctAnswer;

    private bool isActivated = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player && !isActivated)
        {
            isActivated = true;
            textBars.SetActive(true);

            // Generate random positions for the text bars
            // You can adjust this based on your UI setup
            Vector3[] barPositions = new Vector3[3];
            // Set positions here

            // Get the text components of the bars
            TextMesh[] texts = textBars.GetComponentsInChildren<TextMesh>();

            // Set text for each bar
            for (int i = 0; i < 3; i++)
            {
                if (i == Random.Range(0, 3))
                    texts[i].text = correctAnswer;
                else
                    texts[i].text = "False Answer";

                // Set position of the text bar
                texts[i].transform.position = barPositions[i];
            }
        }
    }

    public void CheckAnswer(string selectedText)
    {
        if (selectedText == correctAnswer)
        {
            // Code to hide the box
            gameObject.SetActive(false);
        }
        else
        {
            // Code for wrong answer handling (optional)
        }
    }
}
