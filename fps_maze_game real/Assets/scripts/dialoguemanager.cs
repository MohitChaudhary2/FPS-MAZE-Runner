using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialoguemanager : MonoBehaviour
{
    public Text nametext;
    public Text dialoguetext;
    public FirstPerson controller;

    public Animator animator;

   private Queue<string> sentences;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }
    public void startdialogue(Dialogue dialogue)
    {
        animator.SetBool("isopen", true);
        Debug.Log("starting conversation with " + dialogue.name);
        nametext.text = dialogue.name;

        sentences.Clear();
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        Displaynextsentence();
    }

    public void Displaynextsentence()
    {
        if(sentences.Count==0)
        {
            endDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(typesentences(sentence));
    }

    IEnumerator typesentences(string sentence)
    {
        dialoguetext.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialoguetext.text += letter;
            yield return null;
        }
    }

    private void endDialogue()
    {
        controller.enabled = true;
        animator.SetBool("isopen", false);
        Debug.Log("end of conversation");
    }
}
