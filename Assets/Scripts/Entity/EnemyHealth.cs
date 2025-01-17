using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, Idamagable
{
    [field: SerializeField] public int CurrentHealth { get; set; }
    [field:SerializeField] public int MaxHealth { get; set; } = 3;

    private void Start()
    {
        CurrentHealth = MaxHealth;
    }

    public void Damage(int amount)
    {
        CurrentHealth -= amount;
        Die();
    }

    public void Die()
    {
        if (CurrentHealth <=0)
        {
            Destroy(gameObject);
        }
    }

}
