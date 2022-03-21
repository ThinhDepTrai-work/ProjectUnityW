using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{
    // Check Game is Pause
    public GameObject pauseMenu;

    // Reference To Set Active 
    public bool GameIsPause = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPause)
            {
                // Resume
                Resume();
            }
            else
            {
                // Pause
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPause = false;
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPause = true;
    }

    // Load Menu
    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }


    // Quit Game
    public void ExitGame()
    {
        Application.Quit();
    }


}
