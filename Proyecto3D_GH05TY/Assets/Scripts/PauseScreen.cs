using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScreen : MonoBehaviour
{
    public bool isGamePaused = false;
    [SerializeField] GameObject pauseScreen;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isGamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0f; 
        isGamePaused = true;
        pauseScreen.SetActive(true);

    }

    public void ResumeGame()
    {
        Time.timeScale = 1f; 
        isGamePaused = false;
        pauseScreen.SetActive(false);

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

