using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaseTable : Interactable
{
    public Sprite key;
    public int cutOpen = 0;
    public string s = "";
    public string s1 = "...";
    protected override void Start() {
        base.Start();
        cutOpen = GameManager.instance.vaseOpen;
        if (cutOpen == 1) {
            GetComponent<SpriteRenderer>().sprite = key;
            dt.dialogue.sentences[0] = s1;
        }
    }

    protected override void Interact() {
        base.Interact();
        
        if (cutOpen == 0) {
            s = useInvItem();

            if (s.Equals("shard")) {
                GetComponent<SpriteRenderer>().sprite = key;
                cutOpen = 1;
                GameManager.instance.vaseOpen = cutOpen;
                dt.dialogue.sentences[0] = s1;
                GameManager.instance.inventory.Remove("shard");
            }
        } else {
            if (Input.GetKeyDown("z")) {
                if (GameManager.instance.goldKeyTaken == 0) {
                    if (!GameManager.instance.AddToInv("GOLD KEY")) {
                        Debug.Log("inventory full!");
                    } else {
                        GameManager.instance.goldKeyTaken = 1;
                    }
                } 
            
            }
        }
        
    }
}
