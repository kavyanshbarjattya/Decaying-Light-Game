using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int _health;
    [SerializeField] AudioClip[] hurtClips;
    [SerializeField] AudioClip[] deathClips;

    AudioSource _source;

    EnemyAnim anim;

    bool _dead = false;

    private void Awake()
    {
        _source = GetComponent<AudioSource>();
        anim = GetComponent<EnemyAnim>();
    }

    private void OnEnable()
    {
        _source.Play();
    }
    private void Update()
    {
        if (_health <= 0 && !_dead)
        {
            _dead = true;
            _source.PlayOneShot(deathClips[Random.Range(0, deathClips.Length)]);
            anim.Dead();
            Destroy(gameObject, 1f);
        }
    }
    public void TakeDamage(int damage)
    {
        _source.PlayOneShot(hurtClips[Random.Range(0, hurtClips.Length)]);
        anim.Hurt();
        _health -= damage;
    }
}