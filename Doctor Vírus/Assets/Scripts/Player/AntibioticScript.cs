using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntibioticScript : MonoBehaviour
{
    private WeaponSwitch antibiotic;
    private SpriteRenderer antibioticSprite;
    [SerializeField]
    private AudioClip antibioticUseSound;


    void Start()
    {
        antibiotic = FindObjectOfType<WeaponSwitch>();
    }

    void Update()
    {
        HandleAntibioticUse();
        HandleAntibioticSpriteShowing();
    }

    public void HandleAntibioticUse()
    {
        if (Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.Space) && antibiotic.canUseAntibiotic == true && Time.timeScale == 1)
        {
            if (antibioticUseSound)
                AudioSource.PlayClipAtPoint(antibioticUseSound, transform.position);
            antibiotic.HandleCoroutine();
        }
    }

    void HandleAntibioticSpriteShowing()
    {
        if (antibiotic.canUseAntibiotic == false)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }

        if (antibiotic.canUseAntibiotic == true)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    

}
