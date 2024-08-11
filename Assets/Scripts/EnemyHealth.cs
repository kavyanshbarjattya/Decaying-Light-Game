using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int _health;

    EnemyAnim anim;

    private void Awake()
    {
        anim = GetComponent<EnemyAnim>();
    }
    private void Update()
    {
        if (_health <= 0)
        {
            anim.Dead();
            Destroy(gameObject, 1f);
        }
    }
    public void TakeDamage(int damage)
    {
        anim.Hurt();
        _health -= damage;
    }
}