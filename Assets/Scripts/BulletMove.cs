using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public float speed = 20f;
    public float lifetime = 2f;
    public int damage = 1;

    private Rigidbody2D rb;
    private Vector2 moveDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

     
        float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

       
        rb.velocity = moveDirection * speed;

       
        Destroy(gameObject, lifetime);
    }

    
    public void SetDirection(Vector2 direction)
    {
        moveDirection = direction.normalized;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        // Check if the bullet hits an enemy
        if (hitInfo.CompareTag("Enemy"))
        {
            // Deal damage to the enemy
            EnemyHealth enemy = hitInfo.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }
}
