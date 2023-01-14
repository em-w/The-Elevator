using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : Interactable
{
    public Sprite on;
    public bool isPressed = false;

    protected override void Interact() {
        if (Input.GetKeyDown("z")) {
            GetComponent<SpriteRenderer>().sprite = on;
            isPressed = true;
        }
        
        
    }

}
