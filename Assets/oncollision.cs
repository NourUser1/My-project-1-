using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CollisionDetector : MonoBehaviour
{
    public Canvas collisionCanvas; // Reference to the canvas you want to show

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EditorOnly"))
        {
            // Show the canvas
            collisionCanvas.gameObject.SetActive(true);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        collisionCanvas.gameObject.SetActive(false);
        if (collision.gameObject.CompareTag("EditorOnly"))
        {
            // Hide the canvas
            collisionCanvas.gameObject.SetActive(false);
        }
    }
}
