using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : Interactable
{
    public Keyhole g;
    public Keyhole s;
    public Keyhole i;
    public Keyhole c;
    public Sprite open;
    public int o = 0;

    protected override void Start() {
        base.Start();
        o = GameManager.instance.elevatorOpen;
        if (o == 1) {
            GetComponent<SpriteRenderer>().sprite = open;
        }
    }

    protected override void Update() {
        base.Update();
        if (o == 0) {
            if ((g.unlocked == 1) && (s.unlocked == 1) && (i.unlocked == 1) && (c.unlocked == 1)) {
                GetComponent<SpriteRenderer>().sprite = open;
                o = 1;
                GameManager.instance.elevatorOpen = 1;
            }
        }
    }

    protected override void Interact() {
        if (o == 1) {
            if (Input.GetKeyDown("z")) {
                GameManager.instance.SaveState();
                UnityEngine.SceneManagement.SceneManager.LoadScene("End");
            
            }
        } else {
            base.Interact();
        }
    }
}
