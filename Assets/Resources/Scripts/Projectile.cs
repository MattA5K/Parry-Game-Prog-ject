using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Projectile Properties")]
    public float speed;
    [SerializeField] private bool isHoming;

    private Transform player;
    private Vector2 target;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        if(player == null )
        {
            Debug.LogError("player not found!");
        }
        target = new Vector2(player.position.x, player.position.y);
    }

    private void Update()
    {
        if (isHoming)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            if (transform.position.x == target.x && transform.position.y == target.y)
            {
                DestroyProjectile();
            }
        }
        else
        {

            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
            if (transform.position.x == target.x && transform.position.y == target.y)
            {
                DestroyProjectile();

            }

        }

        

        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
            if (other.CompareTag("Player"))
            {
                DestroyProjectile();
                Debug.Log("Projectile hit Player");
            }
    }
    
    void DestroyProjectile()
        {
            Destroy(gameObject);
        }
}
