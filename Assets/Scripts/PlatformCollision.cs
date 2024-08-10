using System.Collections;
using UnityEngine;
public class PlatformCollision : MonoBehaviour
{
    GameObject oneWayCollider;
    Collider2D playerCollider;

    private void Awake()
    {
        playerCollider = GetComponent<Collider2D>();
    }

    public void DownPerformed()
    {
        if (oneWayCollider != null)
        {
            StartCoroutine(IgnoreCollisions());
        }
    }

    IEnumerator IgnoreCollisions()
    {
        BoxCollider2D collider2D = oneWayCollider.GetComponent<BoxCollider2D>();

        Physics2D.IgnoreCollision(playerCollider, collider2D);
        yield return new WaitForSeconds(.25f);
        Physics2D.IgnoreCollision(playerCollider, collider2D, false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("OneWay"))
        {
            oneWayCollider = collision.gameObject;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("OneWay"))
        {
            oneWayCollider = null;
        }
    }
}