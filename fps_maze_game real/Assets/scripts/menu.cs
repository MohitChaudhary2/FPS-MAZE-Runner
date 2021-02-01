using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public GameObject loadingscreen;
    public Slider Slider;
    public void PlayGame()
    {
        loadingscreen.SetActive(true);
        StartCoroutine(Loadasyncronously());

    }
    IEnumerator Loadasyncronously()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync("levelmenu");
        
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            //Debug.Log(progress);
            Slider.value = progress;
            //progresstext.text = progress * 100 + "%";
            yield return null;
        }
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
