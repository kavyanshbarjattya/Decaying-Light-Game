using UnityEngine;
public class EnemyAI : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5;
    [SerializeField] float jumpForce = 12;
    [SerializeField] float jumpThreshold = 1.5f;

    bool jumpReq;
    float horizontalDir;
    float verticalDir;

    EnemyAnim anim;

    Rigidbody2D rb;
    Transform player;

    private void Awake()
    {
        anim = GetComponentInChildren<EnemyAnim>();
        rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerMovement>().transform;
    }

    private void Start()
    {
        jumpReq = true;
    }

    private void Update()
    {
        if (anim.isDead) return;


        Movement();

        Jump();
    }
    void Movement()
    {
        horizontalDir = player.position.x - transform.position.x;
        horizontalDir = Mathf.Clamp(horizontalDir, -1, 1);

        if(horizontalDir < 0)
        {
            transform.localScale = new Vector2(-1, 1);
        }
        else if(horizontalDir > 0)
        {
            transform.localScale = new Vector2(1, 1);
        }

        transform.Translate(horizontalDir * Vector2.right * moveSpeed * Time.deltaTime);
    }

    void Jump()
    {
        verticalDir = player.position.y - transform.position.y;
        if(verticalDir >= jumpThreshold && Mathf.Abs(horizontalDir) < 1 && jumpReq)
        {
            Invoke("DelayedJump", .5f);
            jumpReq = false;
        }
    }
    void DelayedJump()
    {
        anim.Jump();
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        jumpReq = true;
    }
}