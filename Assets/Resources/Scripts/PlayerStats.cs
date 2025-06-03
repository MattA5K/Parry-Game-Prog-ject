using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour, IAttackable
{
    [SerializeField] private int health;



    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

}
