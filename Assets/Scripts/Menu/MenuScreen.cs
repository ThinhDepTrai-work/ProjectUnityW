using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScreen : MonoBehaviour
{
    // Load Gameplay Scene
    public void PlayGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Home");
    }

    // Quit Game
    public void Quit()
    {
        Application.Quit();
    }
}
