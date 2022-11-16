using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    [SerializeField]
    private float speed;
    
    private float startFollowDistance = 1;
    public bool isFollowing = false;

    private Transform player;
    private WeaponSwitch antibiotic;

    [SerializeField]
    private GameObject itemDrop;

    [SerializeField]
    private AudioClip slimeDeath;

    [SerializeField]
    private AudioClip heartBeat;

    [SerializeField]
    private GameObject particleEffect;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        antibiotic = FindObjectOfType<WeaponSwitch>();
    }

    void FixedUpdate()
    {
        // If the player and the enemy reach a certain distance, the enemy starts following
        if (Vector2.Distance(transform.position, player.position) < startFollowDistance)
        {
            isFollowing = true;
        }
        // If is following true, move the enemy to the player
        if (isFollowing == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }   
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (antibiotic.isImune == true)
        {
            Instantiate(particleEffect, transform.position, Quaternion.identity); // Instantiates the particles
            PlaySlimeAudio(slimeDeath);
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

    void PlaySlimeAudio(AudioClip sound)
    {
        if (sound)
            AudioSource.PlayClipAtPoint(sound, transform.position);
    }
}
