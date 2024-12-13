using UnityEngine;



[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class CharacterController2D : MonoBehaviour
{
    public LayerMask groundLayer;
    public Animator animator;

    [Header("Movement Params")]
    public float runSpeed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravityScale = 0.0f;

    // components attached to player
    private BoxCollider2D coll;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    // other
    private bool isGrounded();
    private void Awake()
    {
        coll = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = gravityScale > 0 ? gravityScale : 2.0f; // Default gravity scale
        sr = GetComponent<SpriteRenderer>();
    }


    private void FixedUpdate()
    {
        if (DialogueManager.GetInstance().dialogueIsPlaying)
        {
            return;
        }

        UpdateIsGrounded();

        HandleHorizontalMovement();

        HandleJumping();
    }

    void UpdateIsGrounded()
    {
        Bounds colliderBounds = coll.bounds;
        float colliderRadius = coll.size.x * 0.4f * Mathf.Abs(transform.localScale.x);
        Vector3 groundCheckPos = colliderBounds.min + new Vector3(colliderBounds.size.x * 0.5f, -colliderRadius * 0.9f, 0);

        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckPos, colliderRadius, groundLayer);
        isGrounded = colliders.Any(c => c != coll); // Ensure ground layer is used
    }



    void HandleHorizontalMovement()
    {
        Vector2 moveDirection = InputManager.GetInstance().GetMoveDirection();
        rb.velocity = new Vector2(moveDirection.x * runSpeed, rb.velocity.y); // Preserve vertical velocity
        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        animator.SetFloat("Yspeed", rb.velocity.y);
        sr.flipX = rb.velocity.x < 0.0f;
    }


    void HandleVerticalMovement()
    {
        // This method is never called, as I rolled up vertical movement in the horizontal call
        Vector2 moveDirection = InputManager.GetInstance().GetMoveDirection();
    }

    void HandleJumping()
    {
        if (isGrounded && InputManager.GetInstance().GetJumpPressed())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed); // Apply jump force
        }
    }
    private void OnDrawGizmos()
    {
    if (coll != null)
        {
        Gizmos.color = Color.green;
        Bounds colliderBounds = coll.bounds;
        float colliderRadius = coll.size.x * 0.4f * Mathf.Abs(transform.localScale.x);
        Vector3 groundCheckPos = colliderBounds.min + new Vector3(colliderBounds.size.x * 0.5f, -colliderRadius * 0.9f, 0);
        Gizmos.DrawWireSphere(groundCheckPos, colliderRadius);
       }
    }

}