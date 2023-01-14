using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cassette : Collectable
{
    string s = "cassette";

    protected override void Interact() {
        if (Input.GetKeyDown("z")) {
            
            if (!GameManager.instance.AddToInv(s)) {
                Debug.Log("inventory full!");
            } else {
                base.Interact();
                GameManager.instance.TakeCassette1();
            }

            
        }
    }

    protected override void Update() {
        base.Update();
        if (GameManager.instance.cassette1Taken == 1) {
            Destroy(gameObject);
        }
    }
}
