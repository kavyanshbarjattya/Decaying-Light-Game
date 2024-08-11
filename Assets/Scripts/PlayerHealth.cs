using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] AudioClip damageClip, death;
    [SerializeField] GameObject _gameLose;
    AudioSource source;
    public float _health;
    public float _currentHealth;
    PlayerAnimations _playeranim;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
        _playeranim = GetComponent<PlayerAnimations>();
    }

    private void Start()
    {
        _currentHealth = _health;
    }

    private void Update()
    {
        if(_currentHealth <= 0)
        {
           _playeranim.Dead();
            StartCoroutine(DelayForGameLoose());
        }

        MusicLerp.instance.Progress((_currentHealth / _health) / 2);
        PostProcessCntroller.instance.UpdatePostProcessVolume(_currentHealth / _health);
    }
    public void PlayerDamage(float damage)
    {
        source.PlayOneShot(damageClip);
        _currentHealth -= damage;
        _playeranim.Hurt();
    }
    IEnumerator DelayForGameLoose()
    {
        source.PlayOneShot(death);
        yield return new WaitForSeconds(2f); 
        _gameLose.SetActive(true);
        gameObject.SetActive(false);
    }
}
