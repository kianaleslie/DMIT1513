using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    public static void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public static void LoadGame()
    {
        SceneManager.LoadScene(1);
    }
    public static void LoadPauseMenu()
    {
        SceneManager.LoadScene(2);
    }
    public static void LoadGameOver()
    {
        SceneManager.LoadScene(3);
    }
}