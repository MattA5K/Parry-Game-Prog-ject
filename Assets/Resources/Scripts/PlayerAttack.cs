using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    private float timeBetweenAttack;
    public float startTimeBetweenAttack;
    [SerializeField] private InputActionReference attack;

    public Transform attackPos;
    public float attackRange;
    public LayerMask whatIsEnemies;
    public int damage;

    private bool canAttack = true;

    private void OnEnable()
    {
        attack.action.Enable();
        attack.action.performed += PerformAttack;
    }

    private void OnDisable()
    {
        attack.action.performed -= PerformAttack;
        attack.action.Disable();
    }

    private void Update()
    {
        if (!canAttack)
        {
            timeBetweenAttack -= Time.deltaTime;
            if (timeBetweenAttack <= 0f)
            {
                canAttack = true;
            }
        }
    }

    private void PerformAttack(InputAction.CallbackContext context)
    {
        if (!canAttack)
            return;

        // Attack logic
        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
        for (int i = 0; i < enemiesToDamage.Length; i++)
        {
            enemiesToDamage[i].GetComponent<EnemyStats>()?.TakeDamage(damage);
            Debug.Log("Enemy took damage " + i);
        }

        // Reset attack cooldown
        canAttack = false;
        timeBetweenAttack = startTimeBetweenAttack;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
