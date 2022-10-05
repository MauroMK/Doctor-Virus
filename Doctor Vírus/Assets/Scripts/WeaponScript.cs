using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public Transform barrel;
    public GameObject syringuePrefab;
    
    void Update()
    {
        HandleShooting();
    }

    private void HandleShooting()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        Instantiate(syringuePrefab, barrel.position, barrel.rotation);
    }
}
