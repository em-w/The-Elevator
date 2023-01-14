using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : Interactable
{
    protected bool collected;

    protected override void Interact() {
        base.Interact();
        collected = true;
        Destroy(gameObject);
    }

}
