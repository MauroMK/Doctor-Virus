using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    
    public void StartGame()
    {
        SceneManager.LoadScene("Level_1");
        Time.timeScale = 1;
    }

    public void QuitButton()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }

}
