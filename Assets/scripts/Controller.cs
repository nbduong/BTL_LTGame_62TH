using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controler : MonoBehaviour
{

    public GameObject panelPause;
    public GameObject player;
    private void Start()
    {
        panelPause.SetActive(false);

    }
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
        player.SetActive(true);
        Time.timeScale = 1.0f;
        panelPause.SetActive(false);
    }
    public void Pause()
    {
        player.SetActive(false);
        Time.timeScale = 0f;
        panelPause.SetActive(true);
    }
}
