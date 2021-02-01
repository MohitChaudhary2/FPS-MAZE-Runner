using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class storyelement : MonoBehaviour
{
    public Dialogue dialogue;
    public FirstPerson controller;
    private void Start()
    {
        controller.enabled = false;
        Invoke("TriggerDialogue",1f);
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<dialoguemanager>().startdialogue(dialogue);
    }
}
