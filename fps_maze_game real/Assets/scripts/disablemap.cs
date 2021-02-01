using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disablemap : MonoBehaviour
{
    public static bool hintactive;
    public GameObject map;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(hintactive)
        {
            map.SetActive(false);
            
        }
    }
    public void hintclosebutton()
    {
        hintactive = false;
        map.SetActive(true);

    }
}
