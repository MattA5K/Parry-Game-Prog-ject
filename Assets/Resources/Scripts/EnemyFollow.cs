using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    [SerializeField]private float speed;
    [SerializeField] private float stoppingDistance;
    public bool canRetreat;
    [SerializeField] private float retreatDistance;

    public Transform target;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<Transform>();
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position,target.position) > stoppingDistance && target != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        } else if (Vector2.Distance(transform.position, target.position) < stoppingDistance && Vector2.Distance(transform.position, target.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        } else if (Vector2.Distance(transform.position, target.position) < retreatDistance && canRetreat)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, -speed * Time.deltaTime);
        }
    }
}
