using UnityEngine;
using UnityEngine.SceneManagement;

public class move : MonoBehaviour
{
    Rigidbody2D car;
    public int speed = 1;
    public int AI = 0;
    public float wait = 3;
    float t = 0;

    // Gravity variables
    public float gravityScale = 1.0f;
    public float gravity = 9.81f;

    void Awake()
    {
        car = gameObject.AddComponent<Rigidbody2D>() as Rigidbody2D;
        car.bodyType = RigidbodyType2D.Dynamic;
    }

    // Update is called once per frame
    void Update()
    {
        wait -= 1 * Time.deltaTime;
        if (wait < 0)
        {
            // Apply gravity
            car.velocity += Vector2.down * gravity * gravityScale * Time.deltaTime;

            if (Input.GetKey(KeyCode.Space))
            {
                car.velocity = new Vector2(2.0f * speed, car.velocity.y);
                t = t + Time.deltaTime;
            }
            else if (AI == 1)
            {
                car.velocity = new Vector2(2.0f * speed, car.velocity.y);
                t = t + Time.deltaTime;
            }
        }
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
