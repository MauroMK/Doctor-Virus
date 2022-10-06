using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractWithButton : MonoBehaviour
{
    [SerializeField]
    private PlayerMovement playerMovement;
    [SerializeField]
    private UnityEvent pressedButton;
    private bool canInteract;

    void Update()
    {
        if (canInteract)
        {
            if (playerMovement.isInteracting == true)
            {
                pressedButton.Invoke();
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
