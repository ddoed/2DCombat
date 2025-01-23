using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, Idamagable
{
    [field: SerializeField] public int CurrentHealth { get; set; }
    [field:SerializeField] public int MaxHealth { get; set; } = 3;

    private CinemachineImpulseSource _impulseSource;
    [SerializeField] private ScreenShakeSO profile;

    public bool HasTakenDamage { get; set; }

    [SerializeField] private ParticleSystem _damageParticle;

    private void Start()
    {
        CurrentHealth = MaxHealth;
        _impulseSource = GetComponent<CinemachineImpulseSource>();
    }

    public void Damage(int amount, Vector2 attackDirection)
    {
        HasTakenDamage = true;
        CurrentHealth -= amount;
        CameraShakeManager.Instance.CameraShakeFromProfile(_impulseSource, profile);
        PlayRandomSFX();
        SpawnDamageParticle(attackDirection);
        Die();
    }

    private void SpawnDamageParticle(Vector2 attackDirection)
    {
        if (_damageParticle == null)
        {
            return;
        }
        Quaternion spawnRotation = Quaternion.FromToRotation(Vector2.right, -attackDirection);
        Instantiate(_damageParticle, transform.position, spawnRotation);
    }

    private void PlayRandomSFX()
    {
        int randomIndex = UnityEngine.Random.Range(1, 5);
        String clipName = "hurt" + randomIndex;
        SoundManager.Instance.PlaySFXFromString(clipName, 1f);
    }

    public void Die()
    {
        if (CurrentHealth <=0)
        {
            Destroy(gameObject);
        }
    }

}
