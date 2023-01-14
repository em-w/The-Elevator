using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaxButton : Interactable
{
    public Sprite w;
    public int waxed = 0;
    public string s = "";
    public string s1 = "The button has been held down with candle wax.";
    protected override void Start() {
        base.Start();
        waxed = GameManager.instance.waxed;
        if (waxed == 1) {
            GetComponent<SpriteRenderer>().sprite = w;
            dt.dialogue.sentences[0] = s1;
        }
    }

    protected override void Interact() {
        base.Interact();
        
        if (waxed == 0) {
            s = useInvItem();

            if (s.Equals("wax")) {
                GetComponent<SpriteRenderer>().sprite = w;
                waxed = 1;
                GameManager.instance.waxed = waxed;
                dt.dialogue.sentences[0] = s1;
                GameManager.instance.inventory.Remove("wax");
            }
        }
        
    }
}
