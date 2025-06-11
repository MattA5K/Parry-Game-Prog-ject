using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeAttack : MonoBehaviour
{
    public MeleeAttack meleeAttack;
    

    public Transform attackOrigin;
    [SerializeField]private float attackRange = 1f;
    [SerializeField]private LayerMask playerLayer;

    private Transform player;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        if (player == null)
        {
            return;
        }

        
            meleeAttack.TriggerAttack();
        
    }
    
    private bool PlayerInRange()
    {
        Vector2 directionToPlayer = (player.position - attackOrigin.position).normalized;

        RaycastHit2D hit = Physics2D.Raycast(attackOrigin.position, directionToPlayer, attackRange, playerLayer);
        return true;
    }

    private void OnDrawGizmosSelected()
    {
        if (attackOrigin != null && player != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(attackOrigin.position, player.position);
        }
    }
}
