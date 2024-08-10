using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpForce = 10f;
    [SerializeField] float groundCheckRadius = 0.2f;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform groundCheck;

    Rigidbody2D rb;
    bool isGrounded, isMoving;
    bool jumpRequest, downRequest;
    float moveInput;

    PlayerControls inputActions;

    PlatformCollision platform;

    void Awake()
    {
        inputActions = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();
        platform = GetComponent<PlatformCollision>();
    }

    private void OnEnable()
    {
        inputActions.Enable();

        inputActions.Movement.Horizontal.performed += Horizontal_performed;
        inputActions.Movement.Jump.performed += Jump_performed;
        inputActions.Movement.Down.performed += Down_performed;

        inputActions.Movement.Horizontal.canceled += Horizontal_canceled;
    }

    private void Horizontal_canceled(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        moveInput = 0;
    }

    private void Down_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (isGrounded)
            downRequest = true;
    }

    private void Jump_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (isGrounded)
            jumpRequest = true;
    }

    private void Horizontal_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        moveInput = obj.ReadValue<float>();
    }

    public bool IsPlayerMoving()
    {
        if(Mathf.Abs(rb.velocity.x) < .1f && Mathf.Abs(rb.velocity.y) < .1f)
        {
            return true;
        }
        return false;
    }

    void Update()
    {
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);


        if (jumpRequest && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpRequest = false;
        }

        if (downRequest && isGrounded)
        {
            platform.DownPerformed();
            downRequest = false;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(groundCheck.position, groundCheckRadius);
    }
}