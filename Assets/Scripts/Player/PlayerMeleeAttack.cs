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

    private void Update()
    {
        if (InputUser.Instance.control.Attack.MeleeAttack.WasPerformedThisFrame())
        {
            Attack();
        }
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

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackTransform.position, attackRange);

    }
}
