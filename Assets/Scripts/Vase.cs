using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : Interactable
{
    public Sprite flowerx1;
    public Sprite flowerx2;
    public Sprite flowerx3;
    public Sprite flowerx4;
    public Sprite flowerx5;
    //int flowersInVase = GameManager.instance.flowersInVase;

    public string s = "";
    public string s1 = "The candles are dripping with wax.";
    protected override void Start() {
        base.Start();
        /*
        if (flowersInVase == 5) {
            GetComponent<SpriteRenderer>().sprite = flowerx5;
        } else {
            
        }
        */
    }

    
}
