using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class globalMD : MonoBehaviour
{
    public static bool isPaused = false;
    public static bool playerLock = false;
    public static int lvl;

    public static void gamePause()
    {
        if (isPaused)
        {
            Time.timeScale = 1;
            isPaused = false;
        }
        else
        {
            Time.timeScale = 0;
            isPaused = true;
        }
    }

    public static void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

   

    public static void qitGame()
    {
        Application.Quit();
    }

}
