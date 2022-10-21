using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntibioticScript : MonoBehaviour
{
    public PlayerMovement player;
    private float buffTime = 2f;
    private float buffSpeed = 1.5f;

    private float normalPlayerSpeed = 0.8f;

    private WeaponSwitch antibiotic;

    void Start()
    {
        antibiotic = FindObjectOfType<WeaponSwitch>();
    }

    void Update()
    {
        HandleAntibioticUse();
    }

    public void HandleAntibioticUse()
    {
        if (Input.GetButtonDown("Fire1") && antibiotic.canUseAntibiotic == true)
        {
            StartCoroutine(UseAntibiotic());
        }
    }

    private IEnumerator UseAntibiotic()
    {
        antibiotic.isImune = true;
        antibiotic.canUseAntibiotic = false;
        player.moveSpeed = buffSpeed;
        yield return new WaitForSeconds(buffTime);
        antibiotic.isImune = false;
        player.moveSpeed = normalPlayerSpeed;
    }

}
