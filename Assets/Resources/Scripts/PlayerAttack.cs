using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    public MeleeAttack meleeAttack;
    [SerializeField] private InputActionReference attack;

    //public Transform attackPos;
    //public float attackRange;
    //public LayerMask whatIsEnemies;
    //public int damage;

    // private bool canAttack = true;

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

    

    private void PerformAttack(InputAction.CallbackContext context)
    {
        /*  if (!canAttack)
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
        */

        meleeAttack.TriggerAttack();
    }

    
}
