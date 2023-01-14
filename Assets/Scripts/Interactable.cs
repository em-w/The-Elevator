using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : Collidable
{
    public DialogueTrigger dt;

    protected override void OnCollide(Collider2D coll) {
        if (coll.name == "Player") {
            Interact();
        }
    }

    protected virtual void Interact() {
        if (Input.GetKeyDown("z")) {
            if (GameManager.instance.speaking == false) {
                dt.TriggerDialogue();
                dt.setUsedMessage();
            }
            
        }
    }

    protected string useInvItem () {
        string s = "";
        if (Input.GetKeyDown("1")) {
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
        return s;
    }
}
