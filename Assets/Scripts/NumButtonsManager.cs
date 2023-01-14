using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumButtonsManager : MonoBehaviour
{
    public NumButton n1;
    public NumButton n2;
    public NumButton n3;
    public NumButton n4;
    public NumButton n5;
    public NumButton n6;
    public NumButton n7;
    public NumButton n8;
    public NumButton n9;

    public DialogueTrigger dt;

    void Update() {
        if (n3.isButtonOn && n5.isButtonOn && n6.isButtonOn && !(n1.isButtonOn || n2.isButtonOn || n4.isButtonOn || n7.isButtonOn || n8.isButtonOn || n9.isButtonOn)) {
            if (GameManager.instance.ironKeyTaken == 0 && GameManager.instance.matchesTaken == 0){
                GameManager.instance.AddToInv("IRON KEY");
                GameManager.instance.AddToInv("matches");
                GameManager.instance.TakeMatchesAndIKey();
                dt.TriggerDialogue();
            }
        }
    }
}
