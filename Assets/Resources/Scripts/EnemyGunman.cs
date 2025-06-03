using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunman : MonoBehaviour
{
    
    private float timeBetweenShots;
    [SerializeField]private float startTimeBetweenShots;


    public GameObject projectile;
    private Transform player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        timeBetweenShots = startTimeBetweenShots;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBetweenShots <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBetweenShots = startTimeBetweenShots;
        } else
        {
            timeBetweenShots -= Time.deltaTime;
        }
    }
}
