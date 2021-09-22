using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float climbSpeed;
    public float jumpForce;
    
    private bool _isJumping;
    private bool _isGrounded;
    [HideInInspector]
    public bool isClimbing;
    
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask collisionLayers;
    
    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public CapsuleCollider2D playerCollider;
    
    private Vector3 _velocity = Vector3.zero;
    
    private float _horizontalMovement;
    private float _verticalMovement;

    public static PlayerMovement Instance;
    
    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("More than one instance of player health");
            return;
        }

        Instance = this;
    }

    private void Update()
    {
        _horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.fixedDeltaTime;
        _verticalMovement = Input.GetAxis("Vertical") * climbSpeed * Time.fixedDeltaTime;

        if (Input.GetButtonDown("Jump") && _isGrounded && !isClimbing)
        {
            _isJumping = true;
        }

        Flip(rb.velocity.x);

        float characterVelocity = Mathf.Abs(rb.velocity.x);
        animator.SetFloat("Speed", characterVelocity);
        animator.SetBool("IsClimbing", isClimbing);
    }

    void FixedUpdate()
    {
        _isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, collisionLayers);
        
        MovePlayer(_horizontalMovement, _verticalMovement);
    }

    void MovePlayer(float horizontalMovement, float verticalMovement)
    {
        if (!isClimbing)
        {
            Vector3 targetVelocity = new Vector2(horizontalMovement, rb.velocity.y);
            rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref _velocity, .05f);

            if (_isJumping)
            {
                rb.AddForce(new Vector2(0f, jumpForce));
                _isJumping = false;
            }
        }
        else
        {
            Vector3 targetVelocity = new Vector2(0, verticalMovement);
            rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref _velocity, .05f);
        }
    }
    
    void Flip(float _velocity)
    {
        if (_velocity > 0.1f)
        {
            spriteRenderer.flipX = false;
        }
        else if (_velocity < -0.1f)
        {
            spriteRenderer.flipX = true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
