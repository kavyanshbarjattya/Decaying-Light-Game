using UnityEngine;
public class PlayerAnimations : MonoBehaviour
{
    Animator animator;

    public bool isDead;
    public bool isRunning;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        animator.SetBool("running", isRunning);
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