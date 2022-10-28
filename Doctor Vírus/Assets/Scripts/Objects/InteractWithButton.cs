using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractWithButton : MonoBehaviour
{

    [SerializeField]
    private GameObject hintText;

    [SerializeField]
    private PlayerMovement player;

    [SerializeField]
    private bool needCheckInventory;

    [SerializeField]
    private string itemName;

    [SerializeField]
    private UnityEvent pressedButton;
    
    private bool canInteract;
    private bool canUseAgain = true;

    [SerializeField]
    private AudioClip doorSound;

    void Update()
    {
        if (canInteract)
        {
            if (canInteract && player.isInteracting == true && canUseAgain == true)
            {
                if (needCheckInventory)
                {
                    if (player.HaveItem(itemName))
                    {
                        PlayDoorSound();
                        pressedButton.Invoke();
                        canUseAgain = false;
                    }
                }
                else
                {
                    PlayDoorSound();
                    pressedButton.Invoke();
                    canUseAgain = false;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        canInteract = true;
        if (other.gameObject.tag == "Player" && canUseAgain == true)
        {
            hintText.SetActive(true);
        }
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        canInteract = false;
        hintText.SetActive(false);
    }

    private void PlayDoorSound()
    {
        if (doorSound)
            AudioSource.PlayClipAtPoint(doorSound, transform.position);
    }
}
