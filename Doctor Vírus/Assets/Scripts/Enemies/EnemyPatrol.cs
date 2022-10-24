using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private float waitTime;
    public float startWaitTime;

    public string weakness;

    public Transform[] moveSpots;

    private int randomSpot;

    [SerializeField]
    private GameObject itemDrop;

    [SerializeField]
    private AudioClip virusDeath;

    [SerializeField]
    private GameObject particleEffect;

    void Start()
    {
        waitTime = startWaitTime;
        randomSpot = Random.Range(0, moveSpots.Length);
    }

    void FixedUpdate()
    {
        // Makes the enemy move in random positions between some moveSpots setted
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                randomSpot = Random.Range(0, moveSpots.Length);
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == weakness)
        {
            Instantiate(particleEffect, transform.position, Quaternion.identity); // Instantiates the particles
            if (virusDeath)
                AudioSource.PlayClipAtPoint(virusDeath, transform.position);
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
