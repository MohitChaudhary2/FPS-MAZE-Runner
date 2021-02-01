using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pausemenu : MonoBehaviour
{
    public GameObject pausemenuUI;
    public gamemanager level;
    public void resume()
    {
        Time.timeScale = 1f;
        pausemenuUI.SetActive(false);
    }
    public void pausebutton()
    {
        Time.timeScale = 0f;
        pausemenuUI.SetActive(true);
    }
    public void backtomenu()
    {
        Time.timeScale = 1f;
        PlayerPrefs.SetInt("goldbars", level.g);
        SceneManager.LoadScene("levelmenu");
    }
    public void quitbutton()
    {
        Time.timeScale = 1f;
        Application.Quit();
    }
}
