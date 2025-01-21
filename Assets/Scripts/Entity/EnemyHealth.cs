using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, Idamagable
{
    [field: SerializeField] public int CurrentHealth { get; set; }
    [field:SerializeField] public int MaxHealth { get; set; } = 3;

    private CinemachineImpulseSource _impulseSource;
    public ScreenShakeSO profile;

    public bool HasTakenDamage { get; set; }

    private void Start()
    {
        CurrentHealth = MaxHealth;
        _impulseSource = GetComponent<CinemachineImpulseSource>();
    }

    public void Damage(int amount)
    {
        HasTakenDamage = true;
        CurrentHealth -= amount;
        //CameraShakeManager.Instance.CameraShake(_impulseSource);
        CameraShakeManager.Instance.CameraShakeFromProfile(_impulseSource, profile);
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
