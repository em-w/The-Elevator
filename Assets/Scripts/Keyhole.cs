using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyhole : Interactable
{
    public Sprite key;
    public int unlocked = 0;
    public string keyName;
    public string s = "";
    
    protected override void Start() {
        base.Start();
        if (keyName.Equals("GOLD KEY")) {
            unlocked = GameManager.instance.gUnlocked;
        } else if (keyName.Equals("SILVER KEY")) {
            unlocked = GameManager.instance.sUnlocked;
        } else if (keyName.Equals("IRON KEY")) {
            unlocked = GameManager.instance.iUnlocked;
        }else  {
            unlocked = GameManager.instance.cUnlocked;
        }
        if (unlocked == 1) {
            GetComponent<SpriteRenderer>().sprite = key;
        }
    }

    protected override void Interact() {
        base.Interact();
        
        if (unlocked == 0) {
            s = useInvItem();

            if (s.Equals(keyName)) {
                GetComponent<SpriteRenderer>().sprite = key;
                unlocked = 1;
                if (keyName.Equals("GOLD KEY")) {
                    GameManager.instance.gUnlocked = unlocked;
                } else if (keyName.Equals("SILVER KEY")) {
                   GameManager.instance.sUnlocked = unlocked;
                } else if (keyName.Equals("IRON KEY")) {
                    GameManager.instance.iUnlocked = unlocked;
                } else {
                    GameManager.instance.cUnlocked = unlocked;
                }
                //dt.dialogue.sentences[0] = s1;
                GameManager.instance.inventory.Remove(keyName);
            }
        }
    }
}
