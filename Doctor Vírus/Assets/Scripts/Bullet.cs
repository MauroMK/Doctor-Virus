using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] 
    private float bulletSpeed;

    [SerializeField]
    private AudioClip itemBreak;

    void Update()
    {
        // Sends the bullet forward
        transform.Translate(Vector2.right * bulletSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Virus")
        {
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Fungus")
        {
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Bacterium")
        {
            Destroy(gameObject);
        }

        if (other.gameObject.layer == 6)
        {
            if (itemBreak)
                AudioSource.PlayClipAtPoint(itemBreak, transform.position);
            Destroy(gameObject);
        }
    }
}
