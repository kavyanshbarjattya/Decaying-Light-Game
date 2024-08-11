using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackEvent : MonoBehaviour
{
    PlayerHealth playerHealth;
    [SerializeField] float _attackingDamage;

    private void Awake()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
    }
    public void GiveDamage()
    {
        playerHealth.PlayerDamage(_attackingDamage);
    }
}
