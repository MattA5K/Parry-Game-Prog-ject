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
        
            if (timeBetweenShots <= 0 && player != null)
            {
                Instantiate(projectile, transform.position, Quaternion.identity);
                timeBetweenShots = startTimeBetweenShots;
                /*
                 * This still runs when the player is "disabled"
                 * Maybe once it got found at start, it shows up as not null
                 * therefore they keep spawning boolets
                 * 
                 */
            }
            else
            {
                timeBetweenShots -= Time.deltaTime;
            }
        

        
    }
}
