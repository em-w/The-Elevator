using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : Interactable
{   
    public Sprite laidEgg;
    public Sprite cageOpened;
    public int phase = 0;
    public string s = "";
    public string s1 = "Looks like the bird laid... a gem?";
    public string s3 = "You got a gem and the COPPER KEY.";
    public string s2 = "The cage door has been opened.";
    public Buttons b1;
    public WaxButton b2;
    protected override void Start() {
        base.Start();
        phase = GameManager.instance.birdPhase;
        if (phase == 1) {
            GetComponent<SpriteRenderer>().sprite = laidEgg;
            dt.dialogue.sentences[0] = s1;
        } else if (phase == 2) {
            GetComponent<SpriteRenderer>().sprite = cageOpened;
            dt.dialogue.sentences[0] = s2;
        }
    }
    protected override void Interact() {
        base.Interact();
        if (phase != 2) {
            s = useInvItem();

            if (s.Equals("beetle")) {
                GetComponent<SpriteRenderer>().sprite = laidEgg;
                phase = 1;
                GameManager.instance.birdPhase = phase;
                dt.dialogue.sentences[0] = s1;
                GameManager.instance.inventory.Remove("beetle");
            }

        } else {
            if (Input.GetKeyDown("z")) {
                if (GameManager.instance.cKeyAndGemTaken == 0) {
                    if (!GameManager.instance.AddToInv("COPPER KEY") || !GameManager.instance.AddToInv("gem")) {
                        Debug.Log("inventory full!");
                    } else {
                        GameManager.instance.cKeyAndGemTaken = 1;
                    }
                } 
            }
        }
    }

    protected override void Update() {
        base.Update();
        if (b1.isPressed && (b2.waxed == 1) && phase != 2) {
            phase = 2;
            GameManager.instance.birdPhase = phase;
            GetComponent<SpriteRenderer>().sprite = cageOpened;
            dt.dialogue.sentences = new string[] {s3, s2};
        }
    }
    
    
}
