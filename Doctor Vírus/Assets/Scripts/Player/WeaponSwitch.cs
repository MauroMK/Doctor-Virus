using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    private int selectedWeapon = 0;
    public bool canShootSyringue;
    public bool canUseAntibiotic;
    public bool canShootAlcohol;
    public bool isImune;
    
    #region Antibiotic
    public PlayerMovement player;
    private float buffTime = 2f;
    private float buffSpeed = 1f;
    private float normalPlayerSpeed = 0.5f;
    public SpriteRenderer spriteShield;
    #endregion

    #region Sound
    [SerializeField]
    private AudioClip syringuePickupSound;
    [SerializeField]
    private AudioClip alcoholPickupSound;
    [SerializeField]
    private AudioClip antibioticPickupSound;
    [SerializeField]
    private AudioClip playerDeath;
    #endregion

    void Start()
    {
        SelectWeapon();
    }

    void Update()
    {
        HandleMouseWheel();
    }

    void HandleMouseWheel()
    {
        int previousSelectedWeapon = selectedWeapon;

        // Switch weapons through scrollwheel
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (selectedWeapon >= transform.childCount - 1)
            {
                selectedWeapon = 0;
            }
            else 
            {
                selectedWeapon++;
            }
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (selectedWeapon <= 0)
            {
                selectedWeapon = transform.childCount -1;
            }
            else 
            {
                selectedWeapon--;
            }
        }

        // Switch weapons through numbers
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedWeapon = 0;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2)
        {
            selectedWeapon = 1;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3)
        {
            selectedWeapon = 2;
        }

        if (Input.GetKeyDown(KeyCode.Alpha4) && transform.childCount >= 4)
        {
            selectedWeapon = 3;
        }

        if (previousSelectedWeapon != selectedWeapon)
        {
            SelectWeapon();
        }
    }

    void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == selectedWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            i++;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Syringue" && canShootSyringue == false)
        {
            canShootSyringue = true;
            if (syringuePickupSound)
                AudioSource.PlayClipAtPoint(syringuePickupSound, transform.position);
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Antibiotic" && canUseAntibiotic == false)
        {
            canUseAntibiotic = true;
            if (antibioticPickupSound)
                AudioSource.PlayClipAtPoint(antibioticPickupSound, transform.position);
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Alcohol" && canShootAlcohol == false)
        {
            canShootAlcohol = true;
            if (alcoholPickupSound)
                AudioSource.PlayClipAtPoint(alcoholPickupSound, transform.position);
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Fungus" && isImune)
        {
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Fungus" && !isImune)
        {
            if (playerDeath)
                AudioSource.PlayClipAtPoint(playerDeath, transform.position);
            GameManager.instance.ShowGameOver();
            Destroy(gameObject);
            Time.timeScale = 0;
        }
    }

    public void HandleCoroutine()
    {
        StartCoroutine(UseAntibiotic());
    }

    private IEnumerator UseAntibiotic()
    {
        isImune = true;
        canUseAntibiotic = false;
        player.moveSpeed = buffSpeed;
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(buffTime);
        isImune = false;
        player.moveSpeed = normalPlayerSpeed;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }

}
