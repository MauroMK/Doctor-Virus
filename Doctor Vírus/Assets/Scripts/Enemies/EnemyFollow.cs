using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{

    public float speed;
    public float startFollowDistance = 1;

    public bool isFollowing = false;

    public string weakness;

    private Transform player;

    [SerializeField]
    private GameObject itemDrop;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void FixedUpdate()
    {

        if (Vector2.Distance(transform.position, player.position) < startFollowDistance)
        {
            isFollowing = true;
        }

        if (isFollowing == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
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
        Destroy(this.gameObject);
        DropItem();
    }

    private void DropItem()
    {
        Vector2 position = transform.position;
        GameObject item = Instantiate(itemDrop, position, transform.rotation);
    }
}
