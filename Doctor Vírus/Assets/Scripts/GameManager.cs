using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Variables
    public static GameManager instance;

    [Header("References")]
    public GameObject gameOver;
    public GameObject pauseMenu;
    public GameObject inventory;
    public GameObject paperList;
    public GameObject tutorialImage;
    #endregion

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (Time.timeScale == 0)
        {
            inventory.SetActive(false);
        }
        else
        {
            inventory.SetActive(true);
        }
    }

    public void ShowGameOver()
    {
        gameOver.SetActive(true);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene("Level_1");
        Time.timeScale = 1;
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ShowPauseMenu()
    {
        pauseMenu.gameObject.SetActive(!pauseMenu.gameObject.activeSelf);

        paperList.gameObject.SetActive(false);
        tutorialImage.gameObject.SetActive(false);

        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void ResumeLevel()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }

    public void ShowPaperList()
    {
        paperList.SetActive(true);
    }

    public void ClosePaperList()
    {
        paperList.SetActive(false);
    }

    public void ShowTutorialImage()
    {
        tutorialImage.SetActive(true);
    }

    public void CloseTutorialImage()
    {
        tutorialImage.SetActive(false);
    }

    public void LoadFinalScene()
    {
        SceneManager.LoadScene("FinalScene");
    }

}
