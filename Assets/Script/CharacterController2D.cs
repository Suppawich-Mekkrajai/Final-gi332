using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 8f;
    [SerializeField] private float jumpForce = 16f;

    [Header("Ground Check")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundRadius = 0.2f;
    [SerializeField] private LayerMask groundLayer;

    [Header("Settings")]
    [SerializeField] private bool airControl = true;

    private Rigidbody2D rb;
    private bool isGrounded;
    private bool facingRight = true;

    private float horizontalMove = 0f;
    private bool jump = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
        horizontalMove = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }

    void FixedUpdate()
    {
        CheckGround();
        Move(horizontalMove, jump);
        jump = false;
    }

    

    void CheckGround()
    {
        isGrounded = Physics2D.OverlapCircle(
            groundCheck.position,
            groundRadius,
            groundLayer
        );
    }

    void Move(float move, bool jump)
    {
        
        if (isGrounded || airControl)
        {
            rb.velocity = new Vector2(move * moveSpeed, rb.velocity.y);

            if (move > 0 && !facingRight)
                Flip();
            else if (move < 0 && facingRight)
                Flip();
        }

        
        if (isGrounded && jump)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0f); // reset Y
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    void Flip()
    {
        facingRight = !facingRight;

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    
    void OnDrawGizmosSelected()
    {
        if (groundCheck == null) return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundRadius);
    }
}