using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyringueScript : MonoBehaviour
{
    public Transform barrel;
    public GameObject syringuePrefab;
    private SpriteRenderer syringueSprite;

    private WeaponSwitch syringue;
    
    [SerializeField]
    private AudioClip throwSyringueSound;
    
    void Start()
    {
        syringue = FindObjectOfType<WeaponSwitch>();
    }

    void Update()
    {
        HandleShooting();
        HandleSyringueSpriteShowing();
    }

    public void HandleShooting()
    {
        if(Input.GetButtonDown("Fire1") && syringue.canShootSyringue == true)
        {
            if (throwSyringueSound)
                AudioSource.PlayClipAtPoint(throwSyringueSound, transform.position);
            Shoot();
        }
    }

    public void Shoot()
    {
        Instantiate(syringuePrefab, barrel.position, barrel.rotation);
        syringue.canShootSyringue = false;
    }

    void HandleSyringueSpriteShowing()
    {
        if (syringue.canShootSyringue == false)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }

        if (syringue.canShootSyringue == true)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
    }

}
