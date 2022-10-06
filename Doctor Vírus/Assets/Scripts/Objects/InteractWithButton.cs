using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractWithButton : MonoBehaviour
{
    [SerializeField]
    private PlayerMovement player;

    [SerializeField]
    private bool needCheckInventory;

    [SerializeField]
    private string itemName;

    [SerializeField]
    private UnityEvent pressedButton;
    
    private bool canInteract;

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
                        pressedButton.Invoke();
                    }
                }
                else
                {
                    pressedButton.Invoke();
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        canInteract = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        canInteract = false;
    }
}
