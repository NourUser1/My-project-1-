using UnityEngine;

public class ColliderForce2D : MonoBehaviour
{
    public float forceMagnitude = 10f; // Magnitude of the force to apply

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Get the Rigidbody2D component of the object collided with
        Rigidbody2D otherRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();

        // Check if the other object has a Rigidbody2D component
        if (otherRigidbody != null)
        {
            // Calculate the direction from this object to the other object
            Vector2 forceDirection = (collision.transform.position - transform.position).normalized;

            // Apply the force to the other object
            otherRigidbody.AddForce(forceDirection * forceMagnitude, ForceMode2D.Impulse);
        }
    }
}
