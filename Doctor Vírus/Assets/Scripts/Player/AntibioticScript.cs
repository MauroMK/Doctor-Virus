using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntibioticScript : MonoBehaviour
{
    public PlayerMovement player;

    public bool canUseAntibiotic = false;
    private bool isImune = false;
    private float buffTime = 2f;

    void Update()
    {
        HandleAntibioticUse();
    }

    public void HandleAntibioticUse()
    {
        if (Input.GetButtonDown("Fire1") && canUseAntibiotic == true)
        {
            StartCoroutine(UseAntibiotic());
        }
    }

    private IEnumerator UseAntibiotic()
    {
        isImune = true;
        canUseAntibiotic = false;
        player.moveSpeed = 1.5f;
        yield return new WaitForSeconds(buffTime);
        isImune = false;
    }
}
