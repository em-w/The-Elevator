using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : Collectable
{
    string s = "flower";

    protected override void Interact() {
        if (Input.GetKeyDown("z")) {
            
            if (!GameManager.instance.AddToInv(s)) {
                Debug.Log("inventory full!");
            } else {
                base.Interact();
                //GameManager.instance.flowersTaken++;
            }

            
        }
    }

    protected override void Update() {
        base.Update();
        /*
        if (GameManager.instance.flowersTaken == 5) {
            Destroy(gameObject);
        }
        */
    }
}
