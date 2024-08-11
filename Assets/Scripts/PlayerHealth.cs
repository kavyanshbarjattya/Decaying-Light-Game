using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] AudioClip damage, death;

    AudioSource source;
    public float _health;
    PlayerAnimations _playeranim;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
        _playeranim = GetComponent<PlayerAnimations>();
    }

    private void Update()
    {
        if(_health <= 0)
        {
           _playeranim.Dead();
            StartCoroutine(DelayForGameLoose());
        }
    }
    public void PlayerDamage(float damage)
    {
        source.PlayOneShot(this.damage);
        _health -= damage;
        _playeranim.Hurt();
    }
    IEnumerator DelayForGameLoose()
    {
        source.PlayOneShot(death);
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }
}
