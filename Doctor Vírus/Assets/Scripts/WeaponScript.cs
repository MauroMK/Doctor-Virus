using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public Transform barrel;
    public GameObject syringuePrefab;
    public bool shootSyringue = true;
    
    void Update()
    {
        HandleShooting();
    }

    public void HandleShooting()
    {
        if(Input.GetButtonDown("Fire1") && shootSyringue == true)
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        Instantiate(syringuePrefab, barrel.position, barrel.rotation);
        shootSyringue = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Syringue" && shootSyringue == false)
        {
            shootSyringue = true;
            Destroy(other.gameObject);
        }
    }

}
