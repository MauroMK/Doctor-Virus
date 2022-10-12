using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCait : MonoBehaviour
{
    [SerializeField]
    private GameObject itemDrop;

    public float startFollowDistance;
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;
    public float startTimeBtwShots;
    public GameObject projectile;

    public string weakness;

    private float timeBtwShots;
    private Transform player;

    public bool isFollowing = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        timeBtwShots = startTimeBtwShots;
    }

    void Update()
    {
            if (Vector2.Distance(transform.position, player.position) < startFollowDistance)
            {
                isFollowing = true;
            }
            
            if (isFollowing == true)
            {
                // If the distance between the enemy and the player is greater than the amount set, he will run towards the player
                if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
                {
                    transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
                } // if the enemy is near enough, he will stop moving
                else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
                {
                    transform.position = this.transform.position;
                } // if is too near, he will start retreating
                else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
                {
                    transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
                }
            }

        // Shooting time
            
            if (isFollowing == true)
            {
                if (timeBtwShots <= 0)
                {
                    Instantiate(projectile, transform.position, Quaternion.identity);
                    timeBtwShots = startTimeBtwShots;
                }
                else
                {
                    timeBtwShots -= Time.deltaTime;
                }
            }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == weakness)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
        DropItem();
    }

    private void DropItem()
    {
        Vector2 position = transform.position;
        GameObject item = Instantiate(itemDrop, position, transform.rotation);
    }
}
