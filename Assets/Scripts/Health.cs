using System.Diagnostics;
using UnityEngine;

public class Health : MonoBehaviour
{
    protected int MAXHEALTH;
    protected int health;

    public Health(int maxHealth)
    {
        MAXHEALTH = maxHealth;
        health = MAXHEALTH;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health < 0)
            health = 0;

        UnityEngine.Debug.Log("Damaged Taken");
    }

    public int GetCurrentHealth()
    {
        return health;
    }
}
