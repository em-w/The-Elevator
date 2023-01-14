using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowersBeetle : Interactable
{
    string s = "beetle";

    protected override void Start() {
        base.Start();
        if (GameManager.instance.beetleTaken == 1) {
            dt.setUsedMessage();
        }
    }

    // Update is called once per frame
    protected override void Interact() {
        if (Input.GetKeyDown("z")) {
            if (GameManager.instance.beetleTaken == 0) {
                if (!GameManager.instance.AddToInv(s)) {
                    Debug.Log("inventory full!");
                } else {
                    base.Interact();
                    GameManager.instance.TakeBeetle();
                }
            } else {
                base.Interact();
            }
            
        }
    }

    /*

    protected override void Update() {
        base.Update();

        if (GameManager.instance.beetleTaken == 1) {
            dt.setUsedMessage();
        }
    }
    */
}
