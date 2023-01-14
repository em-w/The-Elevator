using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : Interactable
{
    public Sprite sh;
    public int shattered = 0;
    public string s1 = "A broken mirror.";
    protected override void Start() {
        base.Start();
        shattered = GameManager.instance.mirrShattered;
        if (shattered == 1) {
            GetComponent<SpriteRenderer>().sprite = sh;
            dt.dialogue.sentences[0] = s1;
        }
    }

    protected override void Interact() {
        base.Interact();
        
        if (shattered == 0) {
            if (Input.GetKeyDown("z")) {
                GetComponent<SpriteRenderer>().sprite = sh;
                shattered = 1;
                GameManager.instance.mirrShattered = shattered;
            }
        } else {
            if (Input.GetKeyDown("z")) {
                if (GameManager.instance.shardTaken == 0) {
                    if (!GameManager.instance.AddToInv("shard")) {
                        Debug.Log("inventory full!");
                    } else {
                        GameManager.instance.shardTaken = 1;
                    }
                } 
            
            }
        }
        
    }
}
