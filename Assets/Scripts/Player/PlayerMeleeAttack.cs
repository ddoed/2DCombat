using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeAttack : MonoBehaviour
{
    [SerializeField] private Transform attackTransform;
    [SerializeField] private float attackRange = 0.4f;
    [SerializeField] private LayerMask attackableLayer;
    [SerializeField] private int damageAmount = 1;
    [SerializeField] private float attackCD = 0.15f;

    RaycastHit2D[] hits;
    Animator anim;
    private float attackCoolTimeCheck;
    private List<Idamagable> idamagables = new();

    public bool ShouldBeDamage { get; set; }

    private void Start()
    {
        anim = GetComponent<Animator>();
        attackCoolTimeCheck = attackCD;
    }

    private void Update()
    {
        if (InputUser.Instance.control.Attack.MeleeAttack.WasPerformedThisFrame() && attackCoolTimeCheck >= attackCD)
        {
            attackCoolTimeCheck = 0;
            anim.SetTrigger("attack");
        }

        attackCoolTimeCheck += Time.deltaTime;
    }

    private void Attack()
    {
        hits = Physics2D.CircleCastAll(attackTransform.position, attackRange, transform.right, 0, attackableLayer);

        for (int i = 0; i < hits.Length; i++)
        {
            Idamagable health = hits[i].collider.GetComponent<Idamagable>();

            if (health != null)
            {
                health.Damage(damageAmount);
            }
        }
    }

    public IEnumerator AttackAvailable()
    {
        ShouldBeDamage = true;
        while (ShouldBeDamage)
        {
            hits = Physics2D.CircleCastAll(attackTransform.position, attackRange, transform.right, 0, attackableLayer);

            for (int i = 0; i < hits.Length; i++)
            {
                Idamagable enemyHealth = hits[i].collider.GetComponent<Idamagable>();

                if (enemyHealth != null && !enemyHealth.HasTakenDamage)
                {
                    enemyHealth.Damage(damageAmount);
                    idamagables.Add(enemyHealth);
                }
            }
            yield return null; 
        }

        ReturnAttackableState();
    }

    private void ReturnAttackableState()
    {
        foreach (var damagable in idamagables)
        {
            damagable.HasTakenDamage = false;
        }
        idamagables.Clear();
    }

    public void ShouldBeDamageTrue()
    {
        ShouldBeDamage = true;
    }

    public void ShouldBeDamageFalse()
    {
        ShouldBeDamage = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackTransform.position, attackRange);

    }
}
