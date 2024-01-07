using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controler : MonoBehaviour
{
    public void newGame()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }
    public void backToMainMenu()
    {
        SceneManager.LoadScene(1);
    }
    public void Resume()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }
    public void Pause()
    {
        Time.timeScale = 0f;
        SceneManager.LoadScene(2);
    }
}
