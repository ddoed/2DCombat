using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public abstract class BaseHealth : MonoBehaviour, Idamagable
{
    [field: SerializeField] public int CurrentHealth { get; set; }
    [field: SerializeField] public int MaxHealth { get; set; } = 3;
    public bool HasTakenDamage { get; set; }

    [SerializeField] private AudioClip damageClip;
    public string HurtClipName;

    [SerializeField] private ParticleSystem _damageParticle;

    protected virtual void Start()
    {
        CurrentHealth = MaxHealth;
    }

    public abstract void Damage(int amount, Vector2 attackDirection);

    protected void SpawnDamageParticle(Vector2 attackDirection)
    {
        if (_damageParticle == null)
        {
            return;
        }
        Quaternion spawnRotation = Quaternion.FromToRotation(Vector2.right, -attackDirection);
        Instantiate(_damageParticle, transform.position, spawnRotation);
    }

    protected void PlayRandomSFX()
    {
        int randomIndex = UnityEngine.Random.Range(1, 5);
        String clipName = "hurt" + randomIndex;
        SoundManager.Instance.PlaySFXFromString(clipName, 1f);
    }

    public void Die()
    {
        if (CurrentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }


}
