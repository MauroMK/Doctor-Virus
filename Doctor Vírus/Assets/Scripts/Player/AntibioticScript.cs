using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntibioticScript : MonoBehaviour
{
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
            antibiotic.HandleCoroutine();
        }
    }

    

}
