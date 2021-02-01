using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fpsanimator : MonoBehaviour
{
    public Animator fps;
    CharacterController CharacterController;
    public static fpsanimator value;
    public bool ismoving = false;

    private void Awake()
    {
        value = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        CharacterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    public void Update()
    {
        fps.SetBool("moving", ismoving);
        /*if (CharacterController.velocity.magnitude>0 || CharacterController.velocity.magnitude < 0)
        {
            
        }
        else
        {
            fps.SetBool("moving", ismoving);
        }*/

    }
}
