using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class levelloader : MonoBehaviour
{
    //public gamemanager gamemanager;
    public GameObject errortext;
    public Text goldbarnumber;
    [SerializeField] GameObject loadingScene;
    [SerializeField] Slider LoadingBar;
    public Button[] levelbuttons;
    int goldbars;
    int levelreached;
  
    void Start()
    {
        goldbars = PlayerPrefs.GetInt("goldbars", 0);
        levelreached = PlayerPrefs.GetInt("levelreached", 1);
        for (int i = 0; i < levelbuttons.Length; i++)
        {
            if (i + 1 > levelreached)
            {
                
                    levelbuttons[i].interactable = false;
              
            }
        }
    }
    void Update()
    {
        goldbarnumber.text = PlayerPrefs.GetInt("goldbars").ToString();
        
    }
    public void select(string levelname)
    {
        loadingScene.SetActive(true);
        StartCoroutine(LoadSceneAsync(levelname));
       // SceneManager.LoadScene(levelname);
    }
    IEnumerator LoadSceneAsync(string name)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(name);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            //Debug.Log(progress);
            LoadingBar.value = progress;
            //progresstext.text = progress * 100 + "%";
            yield return null;
        }
    }
    
    
    
}
