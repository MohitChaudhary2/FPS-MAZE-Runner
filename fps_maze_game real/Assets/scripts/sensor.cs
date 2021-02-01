using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class sensor : MonoBehaviour
{
    [SerializeField] Animator chestopen;
    //public Collider col;
    [SerializeField] public bool doorkeyfound = false;
    [SerializeField] public bool door = false;
    [SerializeField] GameObject wonui;
    public Camera cam;
    public gamemanager level;
    float range = 3f;
    public bool levelcomplete = false;
    public GameObject keynotfound;
    public GameObject Doorkeyfound;
    public bool buttonoff = true;
    public bool bardoorslcosed = true;
    public AudioSource source;
    public AudioClip coincollect;
    public int eastereggscollected=0;


    // Start is called before the first frame update
    private void Start()
    {
        source = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(cam.transform.position,cam.transform.forward,out hit,range))
        {
            if(hit.transform.tag=="chest")
            {
                chestopen.SetBool("chestfound", true);
                wonui.SetActive(true);
                levelcomplete = true;
                if (SceneManager.GetActiveScene().name == "level12")
                {
                    Debug.Log("congrats you have completed all the levels");
                }
                Invoke("endgame", 4f);
            }
            if(hit.transform.tag == "doorkey" )
            {
                doorkeyfound = true;
            }
            if (hit.transform.tag == "easteregg")
            {
                hit.transform.gameObject.SetActive(false);
                eastereggscollected++;
            }
            if (hit.transform.tag == "goldbar")
            {
                level.g++;
                source.PlayOneShot(coincollect);
                Destroy(hit.transform.gameObject);
            }
            if(hit.transform.tag=="buttonoff")
            {
                buttonoff = false;
            }
            if(hit.transform.tag=="bardoors" && bardoorslcosed)
            {
                bardoorslcosed = false;
            }
            else
            {
                bardoorslcosed = true;
            }

            if (hit.transform.tag == "Door" && !door)
            {
                door = true;
            }
            else
            {
                door = false;
            }
            dikhao();
        }
       
    }
    bool display=false;
   // bool display1 = false;
    void dikhao()
    {
        if (doorkeyfound && !display)
        {
            Doorkeyfound.SetActive(true);
            display = true;
        }
        // if(display)
        //  {
        //      Invoke("band", 4f);
        //  }
        if (door && !doorkeyfound)
        {
            keynotfound.SetActive(true);
            // display1 = true;
        }
     //   if (display1)
     //   {
     //       Invoke("band", 4f);
     //   }
    }
    void band()
    {
        Doorkeyfound.SetActive(false);
        keynotfound.SetActive(false);
    }
    void endgame()
    {
        
        //Time.timeScale = 1f;
        // SceneManager.LoadScene("levelmenu");
        level.levelwon();
    }
}
