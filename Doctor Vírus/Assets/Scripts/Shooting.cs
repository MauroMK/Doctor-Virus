using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject syringuePrefab;
    private float bulletForce = 6f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Creating the syringue
        GameObject syringue = Instantiate(syringuePrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = syringue.GetComponent<Rigidbody2D>();
        // Adding a force so she can fly through the screen
        rb.AddForce(firePoint.forward * bulletForce, ForceMode2D.Force);
    }
}
