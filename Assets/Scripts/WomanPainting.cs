using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WomanPainting : Interactable
{
    public ButtonCircleManager b;
    public Sprite spr1;
    public Sprite spr0;
    public int phase;

    public string s = "";
    public string s1 = "A painting of a woman.";
    protected override void Start() {
        base.Start();
        phase = GameManager.instance.paintingPhase;
        if (phase == 1) {
            GetComponent<SpriteRenderer>().sprite = spr0;
        } else if (phase == 2) {
            GetComponent<SpriteRenderer>().sprite = spr1;
            dt.dialogue.sentences[0] = s1;
        }
    }

    protected override void Interact() {
        if (phase != 0) {
            base.Interact();
            
            if (phase == 1) {
                s = useInvItem();

                if (s.Equals("gem")) {
                    GetComponent<SpriteRenderer>().sprite = spr1;
                    phase = 2;
                    GameManager.instance.paintingPhase = phase;
                    dt.dialogue.sentences[0] = s1;
                    GameManager.instance.inventory.Remove("gem");
                }
            } else if (phase == 2) {
                if (Input.GetKeyDown("z")) {
                    if (GameManager.instance.silverKeyTaken == 0) {
                        if (!GameManager.instance.AddToInv("SILVER KEY")) {
                            Debug.Log("oops");
                        } else {
                            GameManager.instance.silverKeyTaken = 1;
                        }
                    } 
                
                }
            }
        }
        
    }
    
    protected override void Update() {
        base.Update();
        if (GameManager.instance.paintingPhase == 1) {
            GetComponent<SpriteRenderer>().sprite = spr0;
            phase = 1;
        }
    }
}
