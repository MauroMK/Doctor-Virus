using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyringueScript : MonoBehaviour
{
    public Transform barrel;
    public GameObject syringuePrefab;
    private SpriteRenderer SyringueSprite;

    public WeaponSwitch syringue;
    
    void Start()
    {
        syringue = FindObjectOfType<WeaponSwitch>();
    }

    void Update()
    {
        HandleShooting();
    }

    public void HandleShooting()
    {
        if(Input.GetButtonDown("Fire1") && syringue.canShootSyringue == true)
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        Instantiate(syringuePrefab, barrel.position, barrel.rotation);
        syringue.canShootSyringue = false;
    }

    

}
