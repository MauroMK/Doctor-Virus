using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public Transform barrel;
    public GameObject syringuePrefab;
    public bool canShootSyringue = false;
    private SpriteRenderer SyringueSprite;
    
    void Update()
    {
        HandleShooting();
    }

    public void HandleShooting()
    {
        if(Input.GetButtonDown("Fire1") && canShootSyringue == true)
        {
            Shoot();
        }

        if (canShootSyringue == false)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }

        if (canShootSyringue == true)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
        
    }

    public void Shoot()
    {
        Instantiate(syringuePrefab, barrel.position, barrel.rotation);
        canShootSyringue = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Syringue" && canShootSyringue == false)
        {
            canShootSyringue = true;
            Destroy(other.gameObject);
        }
    }

}
