using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footstepssound : MonoBehaviour
{
    public CharacterController controller;
    new AudioSource audio;
    
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.velocity.magnitude > 0 && audio.isPlaying == false)
        {
            
            audio.volume = Random.Range(0.8f, 1f);
            //audio.pitch = Random.Range(0.8f, 1.1f);
            


            audio.Play();
        }
    }
}
