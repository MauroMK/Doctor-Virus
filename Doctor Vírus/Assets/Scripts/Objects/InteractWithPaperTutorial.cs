using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractWithPaperTutorial : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameManager.instance.ShowTutorialImage();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        GameManager.instance.CloseTutorialImage();
    }
}
