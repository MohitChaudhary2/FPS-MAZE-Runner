using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gamemanager : MonoBehaviour
{
    public Text goldbarnumber;
    public static gamemanager manager;
    public GameObject objectivetext;
    public static int levelcompleted;
    public sensor found;
    public GameObject doorkey;
    public GameObject dooropen;
    public GameObject doorclosed;
    public sensor completed;
    public int g;
    public GameObject[] levelimages;
   
    public GameObject bardoorsclosed;
    public GameObject buttonclosed;

    int i;
    private void Awake()
    {
        if(manager!=null)
        {
            Destroy(manager);
        }
        manager = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        g = PlayerPrefs.GetInt("goldbars");
        // goldbarnumber.text = g.ToString();
        i = PlayerPrefs.GetInt("levelreached");
        objectivetext.SetActive(true);
        khareedliya = false;
        
    }

    public void showgoogleAds()
    {
        GoogleAdMob.instance.showads(true);
        
    }


    // Update is called once per frame
    void Update()
    {
        // displays the goldbar number in the game
        goldbarnumber.text = g.ToString();

        // disable objective after 5 sec
        Invoke("disableobjective", 5f);
        
        // check in which scene we currently are and perform the related operation we can also use switch case method to do so...
        if (SceneManager.GetActiveScene().name == "level1")
        {
            if (i <= 1)
            {
                i = 1;
            }
        }
        if (SceneManager.GetActiveScene().name=="level2")
        {
            if (i < 2)
            {
                i = 2;
            }

            working();
            
        }
        if (SceneManager.GetActiveScene().name == "level3")
        {
            if (i < 3)
            {
                i = 3;
            }

            working();
        }
        if (SceneManager.GetActiveScene().name == "level4")
        {
            if (i < 4)
            {
                i = 4;
            }


            working();
        }
        if (SceneManager.GetActiveScene().name == "level5")
        {
            if (i < 5)
            {
                i = 5;
            }

            working();
        }
        if (SceneManager.GetActiveScene().name == "level6")
        {
            if (i < 6)
            {
                i = 6;
            }
            working();
        }
        if (SceneManager.GetActiveScene().name == "level7")
        {
            if (i < 7)
            {
                i = 7;
            }

            working();
        }
        if (SceneManager.GetActiveScene().name == "level8")
        {
            if (i < 8)
            {
                i = 8;
            }

            working();
        }
        if (SceneManager.GetActiveScene().name == "level9")
        {
            if (i < 9)
            {
                i = 9;
            }

            working1();
        }
        if (SceneManager.GetActiveScene().name == "level10")
        {
            if (i < 10)
            {
                i = 10;
            }

            working();
        }
        if (SceneManager.GetActiveScene().name == "level11")
        {
            if (i < 11)
            {
                i = 11;
            }

            working();
        }
        if (SceneManager.GetActiveScene().name == "level12")
        {
            if (i < 12)
            {
                i = 12;
            }


            working();
        }
    }

    private void working1()
    {
        if (!found.buttonoff)
        {
            buttonclosed.SetActive(false);
        }

        if (!found.bardoorslcosed)
        {
            if (!found.buttonoff)
            {
                bardoorsclosed.SetActive(false);
            }
        }
        working();
    }

    void working()
    {
        if (found.doorkeyfound)
        {
            doorkey.SetActive(false);
        }
        
        if (found.door)
        {
            if (found.doorkeyfound)
            {
                dooropen.SetActive(true);
                doorclosed.SetActive(false);
            }        
        }
    }
    void disableobjective()
    {
        //Time.timeScale = 1f;
        objectivetext.SetActive(false);
    }
    public void disablehint()
    {
       // levelimages[j].SetActive(false);
        khareedliya = false;
    }
    public void levelwon()
    {
        if (i == SceneManager.GetActiveScene().buildIndex - 1)
        {
            PlayerPrefs.SetInt("levelreached",i+1);
        }
        PlayerPrefs.SetInt("goldbars", g);
        AdManager.showads.ShowInterstitialAd();
        SceneManager.LoadScene("levelmenu");
    }
    bool khareedliya = false;
    public void BUYWITHGOLDBARS()
    {
        int buildindex = SceneManager.GetActiveScene().buildIndex;
        if (g>=10 && !khareedliya)
        {
            //Time.timeScale = 0;
            khareedliya = true;
            disablemap.hintactive = true;
            
            
            switch (buildindex)
            {
                case 2:
                    //level 1
                    g = g - 10;
                    levelimages[0].SetActive(true);
                    khareedliya = false;
                    break;
                case 3:
                    //level 2
                    g = g - 10;
                    levelimages[1].SetActive(true);
                    khareedliya = false;
                    break;
                case 4:
                    //level 3
                    g = g - 10;
                    levelimages[2].SetActive(true);
                    khareedliya = false;
                    break;
                case 5:
                    //level 4
                    g = g - 10;
                    levelimages[3].SetActive(true);
                    khareedliya = false;
                    break;
                case 6:
                    //level 5
                    g = g - 10;
                    levelimages[4].SetActive(true);
                    khareedliya = false;
                    break;
                case 7:
                    //level 6
                    g = g - 10;
                    levelimages[5].SetActive(true);
                    break;
                case 8:
                    //level 7
                    g = g - 10;
                    levelimages[6].SetActive(true);
                    break;
                case 9:
                    //level 8
                    g = g - 10;
                    levelimages[7].SetActive(true);
                    khareedliya = false;
                    break;
                case 10:
                    //level 9
                    g = g - 10;
                    levelimages[8].SetActive(true);
                    break;
                case 11:
                    //level 10
                    g = g - 10;
                    levelimages[9].SetActive(true);
                    khareedliya = false;
                    break;
                case 12:
                    //level 11
                    g = g - 10;
                    levelimages[10].SetActive(true);
                    khareedliya = false;
                    break;
                case 13:
                    //level 12
                    g = g - 10;
                    levelimages[11].SetActive(true);
                    khareedliya = false;
                    break;
                default:
                    break;
            }
        }
        

    }
    public void afterwathchingads()
    {
        int buildindex = SceneManager.GetActiveScene().buildIndex;
        if (!khareedliya)
        {
            //Time.timeScale = 0;
            khareedliya = true;

            disablemap.hintactive = true;
            switch (buildindex)
            {
                case 2:
                    levelimages[0].SetActive(true);
                    
                    khareedliya = false;
                    break;
                case 3:
                    levelimages[1].SetActive(true);
                    khareedliya = false;
                    break;
                case 4:
                    levelimages[2].SetActive(true);
                    khareedliya = false;
                    break;
                case 5:
                    levelimages[3].SetActive(true);
                    khareedliya = false;
                    break;
                case 6:
                    levelimages[4].SetActive(true);
                    khareedliya = false;
                    break;
                case 7:
                    levelimages[5].SetActive(true);
                    khareedliya = false;
                    break;
                case 8:
                    levelimages[6].SetActive(true);
                    khareedliya = false;
                    break;
                case 9:
                    levelimages[7].SetActive(true);
                    khareedliya = false;
                    break;
                case 10:
                    levelimages[8].SetActive(true);
                    khareedliya = false;
                    break;
                case 11:
                    levelimages[9].SetActive(true);
                    khareedliya = false;
                    break;
                case 12:
                    levelimages[10].SetActive(true);
                    khareedliya = false;
                    break;
                case 13:
                    levelimages[11].SetActive(true);
                    khareedliya = false;
                    break;
                default:
                    break;
            }
        }


    }
}
