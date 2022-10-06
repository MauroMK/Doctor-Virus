using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    [SerializeField]
    private string itemName;

    [SerializeField]
    private AudioClip sound;

    private CircleCollider2D circleCollider2;

    private void Awake()
    {
        circleCollider2 = GetComponent<CircleCollider2D>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            var player = other.gameObject.GetComponent<PlayerMovement>();
            player.AddItem(itemName); // Adds the item to the inventory
            if (sound)
                AudioSource.PlayClipAtPoint(sound, transform.position);
            Destroy(this.gameObject); //Destroy the card image from the scene
        }
    }
}
