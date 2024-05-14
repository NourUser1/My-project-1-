using UnityEngine;

public class DestroyObjectOnClick : MonoBehaviour
{
    public GameObject objectToDestroy; // Reference to the object you want to destroy

    // This method is called when the button is clicked
    public void OnButtonClick()
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
