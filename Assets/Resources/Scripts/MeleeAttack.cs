using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    [Header("Attack Settings")]
    public Transform attackPos;
    public float attackRange;
    public LayerMask whatIsTarget;
    public int damage;
    public float attackCooldown = 1f;

    private bool canAttack = true;
    private float attackTimer;

    private void Update()
    {
        if (!canAttack)
        {
            attackTimer -= Time.deltaTime;
            if (attackTimer <= 0)
            {
                canAttack = true;
            }
        }
    }

    public void TriggerAttack()
    {
        if (!canAttack) return;

        Collider2D[] targets = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsTarget);
        foreach (Collider2D target in targets)
        {
            target.GetComponent<IAttackable>()?.TakeDamage(damage);
        }

        canAttack = false;
        attackTimer = attackCooldown;
    }

    private void OnDrawGizmosSelected()
    {
        if(attackPos != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(attackPos.position, attackRange);
        }
        
    }
}
