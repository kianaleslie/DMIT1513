using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject pauseMenu;
    private bool isPaused = false;
    private bool isOnMainMenu = true;
    Keyboard kb;

    private void Start()
    {
        Time.timeScale = 0;
        // Hide the pause menu initially.
        pauseMenu.SetActive(false);
        kb = Keyboard.current;
    }

    private void Update()
    {
        // Check for the Escape key to toggle the pause menu.
        if (kb.escapeKey.wasPressedThisFrame)
        {
            if (isOnMainMenu)
            {
                // Handle the Escape key on the title screen.
                QuitGame();
            }
            else
            {
                TogglePauseMenu();
            }
        }
    }

    public void StartGame()
    {
        // Start the game by hiding the title screen.
        mainMenu.SetActive(false);
        isOnMainMenu = false;
    }

    public void TogglePauseMenu()
    {
        if (isPaused)
        {
            // Resume the game.
            Time.timeScale = 1;
            isPaused = false;
            pauseMenu.SetActive(false);
        }
        else
        {
            // Pause the game.
            Time.timeScale = 0;
            isPaused = true;
            pauseMenu.SetActive(true);
        }
    }

    public void ReturnToMainMenu()
    {
        // Return to the title screen by reloading the current scene.
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ContinueGame()
    {
        // Continue the game by hiding the pause menu and setting the time scale to 1.
        isPaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        // Quit the application.
        Application.Quit();
    }
}