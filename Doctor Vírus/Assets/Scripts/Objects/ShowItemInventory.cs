using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowItemInventory : MonoBehaviour
{
    #region Images Variables

    [SerializeField]
    private GameObject syringueFull;
    [SerializeField]
    private GameObject syringueEmpty;
    [SerializeField]
    private GameObject antibioticFull;
    [SerializeField]
    private GameObject antibioticEmpty;
    [SerializeField]
    private GameObject alcoholFull;
    [SerializeField]
    private GameObject alcoholEmpty;

    #endregion

    

    private WeaponSwitch weapons;

    void Start()
    {
        weapons = FindObjectOfType<WeaponSwitch>();
    }

    void Update()
    {
        // Item showcase in inventory
        if(weapons.canShootSyringue == true)
        {
            syringueFull.SetActive(true);
            syringueEmpty.SetActive(false);
        }

        if(weapons.canShootSyringue == false)
        {
            syringueFull.SetActive(false);
            syringueEmpty.SetActive(true);
        }

        if(weapons.canUseAntibiotic == true)
        {
            antibioticFull.SetActive(true);
            antibioticEmpty.SetActive(false);
        }

        if(weapons.canUseAntibiotic == false)
        {
            antibioticFull.SetActive(false);
            antibioticEmpty.SetActive(true);
        }

        if(weapons.canShootAlcohol == true)
        {
            alcoholFull.SetActive(true);
            alcoholEmpty.SetActive(false);
        }

        if(weapons.canShootAlcohol == false)
        {
            alcoholFull.SetActive(false);
            alcoholEmpty.SetActive(true);
        }

        // Show item selected in inventory


    }
}
