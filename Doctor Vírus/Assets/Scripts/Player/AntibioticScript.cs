using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntibioticScript : MonoBehaviour
{
    public PlayerMovement player;
    private bool isImune = false;
    private float buffTime = 2f;

    public bool canUseAntibiotic = false;

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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Fungus" && isImune == true)
        {
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Antibiotic" && canUseAntibiotic == false)
        {
            canUseAntibiotic = true;
            Destroy(other.gameObject);
        }
        
    }
}
