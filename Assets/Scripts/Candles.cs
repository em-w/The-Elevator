using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candles : Interactable
{
    public Sprite lit;
    public int isLit = 0;
    public string s = "";
    public string s1 = "The candles are dripping with wax.";
    protected override void Start() {
        base.Start();
        isLit = GameManager.instance.isLit;
        if (isLit == 1) {
            GetComponent<SpriteRenderer>().sprite = lit;
            dt.dialogue.sentences[0] = s1;
        }
    }

    protected override void Interact() {
        base.Interact();
        
        if (isLit == 0) {
            s = useInvItem();

            if (s.Equals("matches")) {
                GetComponent<SpriteRenderer>().sprite = lit;
                isLit = 1;
                GameManager.instance.isLit = isLit;
                dt.dialogue.sentences[0] = s1;
                GameManager.instance.inventory.Remove("matches");
            }
        } else {
            if (Input.GetKeyDown("z")) {
                if (GameManager.instance.waxTaken == 0) {
                    if (!GameManager.instance.AddToInv("wax")) {
                        Debug.Log("inventory full!");
                    } else {
                        GameManager.instance.waxTaken = 1;
                    }
                } 
            
            }
        }
        
    }
}
