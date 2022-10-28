using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlcoholScript : MonoBehaviour
{
    public Transform barrel;
    public GameObject alcoholPrefab;
    private SpriteRenderer alcoholSprite;

    private WeaponSwitch alcohol;
    
    [SerializeField]
    private AudioClip throwAlcoholSound;

    void Start()
    {
        alcohol = FindObjectOfType<WeaponSwitch>();
    }

    void Update()
    {
        HandleShooting();
        HandleAlcoholSpriteShowing();
    }

    public void HandleShooting()
    {
        if(Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.Space) && alcohol.canShootAlcohol == true && Time.timeScale == 1)
        {
            if (throwAlcoholSound)
                AudioSource.PlayClipAtPoint(throwAlcoholSound, transform.position);
            Shoot();
        }
    }

    public void Shoot()
    {
        Instantiate(alcoholPrefab, barrel.position, barrel.rotation);
        alcohol.canShootAlcohol = false;
    }

    void HandleAlcoholSpriteShowing()
    {
        if (alcohol.canShootAlcohol == false)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }

        if (alcohol.canShootAlcohol == true)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
