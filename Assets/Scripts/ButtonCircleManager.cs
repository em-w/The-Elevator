using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCircleManager : MonoBehaviour
{
    public NumButton c1;
    public NumButton c2;
    public NumButton c3;
    public NumButton c4;
    public NumButton c5;
    public NumButton c6;
    public NumButton c7;
    public NumButton c8;
    public NumButton c9;
    public NumButton c10;
    public NumButton c11;
    public NumButton c12;
    public NumButton c13;
    public NumButton c14;
    public NumButton c15;
    public NumButton c16;
    public NumButton c17;
    public NumButton c18;
    public NumButton c19;
    public NumButton c20;

    public bool revealPortrait = false;


    void Update() {
        if (c2.isButtonOn && c6.isButtonOn && c11.isButtonOn && c13.isButtonOn && c19.isButtonOn
         && !(c1.isButtonOn || c3.isButtonOn || c4.isButtonOn || c5.isButtonOn || c7.isButtonOn 
         || c8.isButtonOn || c9.isButtonOn || c10.isButtonOn || c12.isButtonOn || c14.isButtonOn
         || c15.isButtonOn|| c16.isButtonOn|| c17.isButtonOn|| c18.isButtonOn|| c20.isButtonOn)) {
            
            if (GameManager.instance.paintingPhase == 0){      
                GameManager.instance.paintingPhase = 1;
                revealPortrait = true;
            }
        }
        
    }
}
