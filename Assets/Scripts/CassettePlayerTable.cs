using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CassettePlayerTable : Interactable
{
    public DialogueTrigger dt2;
    private string s = "";
    string[] responses = new string[] {"Four doors, four keys.", "Clockwise from twelve."};

    protected override void Interact() {
        base.Interact();

        //if (GameManager.instance.invOpen == true) {
            if (Input.GetKeyDown("1")) {
                Debug.Log("h");
                try {
                    s = GameManager.instance.inventory[0];
                } catch {
                    s = "";
                }
            } else if (Input.GetKeyDown("2")) {
                try {
                    s = GameManager.instance.inventory[1];
                } catch {
                    s = "";
                }
            } else if (Input.GetKeyDown("3")) {
                try {
                    s = GameManager.instance.inventory[2];
                } catch {
                    s = "";
                }
            } else if (Input.GetKeyDown("4")) {
                try {
                    s = GameManager.instance.inventory[3];
                } catch {
                    s = "";
                }
            } else if (Input.GetKeyDown("5")) {
                try {
                    s = GameManager.instance.inventory[4];
                } catch {
                    s = "";
                }
            } else if (Input.GetKeyDown("6")) {
                try {
                    s = GameManager.instance.inventory[5];
                } catch {
                    s = "";
                }
            } else if (Input.GetKeyDown("7")) {
                try {
                    s = GameManager.instance.inventory[6];
                } catch {
                    s = "";
                }
            } else if (Input.GetKeyDown("8")) {
                try {
                    s = GameManager.instance.inventory[7];
                } catch {
                    s = "";
                }
            } else if (Input.GetKeyDown("9")) {
                try {
                    s = GameManager.instance.inventory[8];
                } catch {
                    s = "";
                }
            }
        //} 

        //.Log("string is " + s);

        if (s.Equals("cassette")) {
            dt2.dialogue.sentences[0] = responses[0];
            if (GameManager.instance.speaking == false) {
                s = "";
                dt2.TriggerDialogue();
            }
            
            GameManager.instance.inventory.Remove("cassette");
        } else if (s.Equals("cassette2")) {
            dt2.dialogue.sentences[0] = responses[1];
            if (GameManager.instance.speaking == false) {
                s = "";
                dt2.TriggerDialogue();
            }
            GameManager.instance.inventory.Remove("cassette2");
        }
    }
}
