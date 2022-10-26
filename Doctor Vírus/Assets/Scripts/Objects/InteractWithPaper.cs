using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractWithPaper : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameManager.instance.ShowPaperList();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        GameManager.instance.ClosePaperList();
    }
}
