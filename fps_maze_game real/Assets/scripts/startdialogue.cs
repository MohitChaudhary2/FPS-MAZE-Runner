using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startdialogue : MonoBehaviour
{
    public storyelement startdialogues;
    // Start is called before the first frame update
    void Start()
    {
        startdialogues.TriggerDialogue();
    }

    // Update is called once per frame
}
