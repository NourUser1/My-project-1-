using UnityEngine;

public class JumpController : MonoBehaviour
{
    public float jumpForce = 10f;
    public float horizontalForce = 5f;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public float groundCheckRadius = 0.1f;
    public float interpolationTime = 0.1f;

    private Rigidbody2D rb;
    private Vector3 targetPosition;
    private bool isGrounded;
    private Vector3 targetVelocity;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition = new Vector3(mousePosition.x, mousePosition.y, 0f);
            rb.AddForce(new Vector2(horizontalForce, 0f), ForceMode2D.Impulse);
        }

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (isGrounded && rb.velocity.y == 0)
        {
            targetVelocity = (targetPosition - transform.position).normalized * jumpForce;
            targetVelocity.y = jumpForce;
        }

        if (rb.velocity.y < 0)
        {
            targetVelocity.y = rb.velocity.y;
        }

        rb.velocity = Vector3.Lerp(rb.velocity, targetVelocity, interpolationTime * Time.deltaTime);
    }

    void FixedUpdate()
    {
        if (rb.velocity.y < 0)
        {
            Vector2 currentPosition = rb.position;
            Vector2 targetDirection = (Vector2)targetPosition - currentPosition;
            float targetAngle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
            rb.rotation = Mathf.LerpAngle(rb.rotation, targetAngle, 10f * Time.deltaTime);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == groundLayer)
        {
            isGrounded = true;
            rb.velocity = Vector2.zero;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == groundLayer)
        {
            isGrounded = false;
        }
    }
}