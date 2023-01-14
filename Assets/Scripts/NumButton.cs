using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumButton : Interactable
{
    public Sprite buttonOn;
    public Sprite buttonOff;
    public bool isButtonOn = false;

    protected override void Interact() {
        if (Input.GetKeyDown("z")) {
            if (isButtonOn) {
                GetComponent<SpriteRenderer>().sprite = buttonOff;
            } else {
                GetComponent<SpriteRenderer>().sprite = buttonOn;
            }

            isButtonOn = !isButtonOn;
        }
    }
}
