using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class correct : MonoBehaviour
{

    public Text clickableText; // Reference to the clickable text object
    public GameObject objectToDestroy; // Reference to the object you want to destroy

    void Start()
    {
        // Check if the clickableText reference is assigned
        if (clickableText == null)
        {
            Debug.LogError("Clickable Text reference not set!");
            return;
        }

        // Add a listener for the text object's click event
        clickableText.GetComponent<Button>().onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        // Check if the objectToDestroy reference is assigned
        if (objectToDestroy != null)
        {
            // Destroy the specified object
            Destroy(objectToDestroy);
        }
        else
        {
            Debug.LogError("Object to Destroy reference not set!");
        }
    }
}