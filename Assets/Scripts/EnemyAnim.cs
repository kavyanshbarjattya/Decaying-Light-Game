using UnityEngine;
public class EnemyAnim : MonoBehaviour
{
    Animator animator;

    public bool isDead;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void Jump()
    {
        animator.SetTrigger("jump");
    }
    public void Attack()
    {
        animator.SetTrigger("attack");
    }
    public void Hurt()
    {
        animator.SetTrigger("hurt");
    }
    public void Dead()
    {
        isDead = true;
        animator.SetTrigger("dead");
    }
}