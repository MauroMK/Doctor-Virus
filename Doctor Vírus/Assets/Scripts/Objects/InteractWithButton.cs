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

    [SerializeField]
    private AudioClip doorSound;

    void Update()
    {
        if (canInteract)
        {
            if (canInteract && player.isInteracting == true)
            {
                if (needCheckInventory)
                {
                    if (player.HaveItem(itemName))
                    {
                        if (doorSound)
                            AudioSource.PlayClipAtPoint(doorSound, transform.position);
                        pressedButton.Invoke();
                    }
                }
                else
                {
                    if (doorSound)
                        AudioSource.PlayClipAtPoint(doorSound, transform.position);
                    pressedButton.Invoke();
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        canInteract = true;
        if (other.gameObject.tag == "Player")
        {
            hintText.SetActive(true);
        }
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        canInteract = false;
        hintText.SetActive(false);
    }
}
