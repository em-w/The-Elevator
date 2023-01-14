using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Queue<string> sentences;
    public Text nameText;
    public Text dialogueText;
    public Animator animator; // allow DialogueManager to access animator
    private bool readyForNext = false;
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue) {
        sentences.Clear();
        dialogueText.text = "";
        GameManager.instance.speaking = true;
        animator.SetBool("isOpen", true);
        Debug.Log("Dialogue starting with " + dialogue.name);
        
        foreach (string s in dialogue.sentences) {
            sentences.Enqueue(s);
            //Debug.Log(s);
        }
        
        DisplayNextSentence();
        readyForNext = false;
    }

    // print letters of sentence one by one
    IEnumerator TypeSentence (string sentence) {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray()) {
            dialogueText.text += letter;
            yield return null; // wait one frame between each letter
        }
    }

    public void Update() {
        if (Input.GetKeyUp("z") || Input.GetKeyUp("1") || Input.GetKeyUp("2") || Input.GetKeyUp("3") || Input.GetKeyUp("4") || Input.GetKeyUp("5") || Input.GetKeyUp("6") || Input.GetKeyUp("7") || Input.GetKeyUp("8") || Input.GetKeyUp("9") ) {
            readyForNext = true;
        }
        if (!GameManager.instance.invOpen) {
            if (Input.GetKeyDown("z") && GameManager.instance.speaking == true && readyForNext == true) {
                if (sentences.Count != 0) {
                    DisplayNextSentence();
                } else {
                    EndDialogue();
                }
                
            } 
        }
    }

    public void DisplayNextSentence() {
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        
    }

    public void EndDialogue() {
        animator.SetBool("isOpen", false);
        Debug.Log("Dialogue ended!");
        GameManager.instance.speaking = false;
        sentences.Clear();
    }

    
}
