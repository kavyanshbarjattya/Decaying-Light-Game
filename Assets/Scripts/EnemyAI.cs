using UnityEngine;
public class EnemyAI : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5;
    [SerializeField] float jumpForce = 12;
    [SerializeField] float jumpThreshold = 1.5f;
    [SerializeField] float _attackingRange;
    [SerializeField] LayerMask _playerMask;

    bool jumpReq;
    float horizontalDir;
    float verticalDir;

    EnemyAnim anim;

    PlayerHealth _playerhealth;
    Rigidbody2D rb;
    Transform player;
   

    private void Awake()
    {
        anim = GetComponentInChildren<EnemyAnim>();
        rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerMovement>().transform;
        _playerhealth = FindObjectOfType<PlayerHealth>();
    }

    private void Start()
    {
        jumpReq = true;
    }

    private void Update()
    {
        if (anim.isDead) return;
        RaycastHit2D hit;
        hit = Physics2D.Raycast(transform.position, transform.forward, _attackingRange , _playerMask);
        if (hit && _playerhealth._health > 0)
        {
            anim.Attack();
        }
        else if (!hit && _playerhealth._health <= 0)
        {
            anim.Idle();
        }
        else
        {
            Movement();
            Jump();
        }


    }
    void Movement()
    {
        horizontalDir = player.position.x - transform.position.x;
        float horizontalDirClamped = Mathf.Clamp(horizontalDir, -1, 1);

        if(horizontalDirClamped < 0)
        {
            transform.localScale = new Vector2(-1, 1);
        }
        else if(horizontalDirClamped > 0)
        {
            transform.localScale = new Vector2(1, 1);
        }

        transform.Translate(horizontalDirClamped * Vector2.right * moveSpeed * Time.deltaTime);
    }

    void Jump()
    {
        verticalDir = player.position.y - transform.position.y;
        if(verticalDir >= jumpThreshold && Mathf.Abs(horizontalDir) < 3 && jumpReq)
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


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            Invoke("DelayedJump", 0);
        }
    }
}