using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float _health;
    PlayerAnimations _playeranim;

    private void Awake()
    {
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
        _health -= damage;
        _playeranim.Hurt();
    }
    IEnumerator DelayForGameLoose()
    {
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }
}
