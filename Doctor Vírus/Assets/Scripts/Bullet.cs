using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed;

    void Update()
    {
        transform.Translate(Vector2.right * bulletSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Slime" || other.gameObject.layer == 6)
        {
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Fungus" || other.gameObject.layer == 6)
        {
            Destroy(gameObject);
        }
    }
}
