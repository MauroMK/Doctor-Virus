using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyringueScript : MonoBehaviour
{
    public Transform barrel;
    public GameObject syringuePrefab;
    private SpriteRenderer SyringueSprite;

    public bool canShootSyringue;
    
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
