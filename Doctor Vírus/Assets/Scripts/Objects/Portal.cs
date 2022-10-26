using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject prototypeScreen;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            ShowPrototypeScreen();
        }
    }

    public void ShowPrototypeScreen()
    {
        prototypeScreen.SetActive(true);
    }
}
