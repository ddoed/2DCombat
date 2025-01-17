using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Idamagable
{
    public int CurrentHealth { get;set; }
    public int MaxHealth { get;set; }

    public void Damage(int amount);

    public void Die();
}
