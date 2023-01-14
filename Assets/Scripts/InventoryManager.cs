using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public Text col1;
    public Text col2;
    public Text col3;
    public Text title;
    public Animator animator;
    private bool currentlyShowing = false;

    void Update()
    {
        if (Input.GetKeyDown("x")) {
            if (currentlyShowing == false) {
                if (!GameManager.instance.speaking) {
                    ShowInventory();
                }
            } else {
                if (GameManager.instance.invOpen) {
                    HideInventory();
                }
            }
        }

        if (Input.GetKeyUp("x")) {
            currentlyShowing = !currentlyShowing;
        }

        
        if (Input.GetKeyDown("1") || Input.GetKeyDown("2") || Input.GetKeyDown("3") || Input.GetKeyDown("4") || Input.GetKeyDown("5") || Input.GetKeyDown("6") || Input.GetKeyDown("7") || Input.GetKeyDown("8") || Input.GetKeyDown("9")) {
            currentlyShowing = false;
            HideInventory();
        }
        
        
    }

    private void ShowInventory() {
        GameManager.instance.speaking = true;
        GameManager.instance.invOpen = true;
        animator.SetBool("isOpen", true);
        col1.text = "";
        col2.text = "";
        col3.text = "";
        title.text = "INVENTORY";

        for (int i = 1; i <= 3; i++) {
            col1.text += i + ". ";
            try {
                col1.text += GameManager.instance.inventory[i - 1] + "\n";
            } catch {
                col1.text += "\n";
            }
        }
        for (int i = 4; i <= 6; i++) {
            col2.text += i + ". ";
            try {
                col2.text += GameManager.instance.inventory[i - 1] + "\n";
            } catch {
                col2.text += "\n";
            }
        }
        for (int i = 7; i <= 9; i++) {
            col3.text += i + ". ";
            try {
                col3.text += GameManager.instance.inventory[i - 1] + "\n";
            } catch {
                col3.text += "\n";
            }
        }
    }

    private void HideInventory() {
        animator.SetBool("isOpen", false);
        GameManager.instance.speaking = false;
        GameManager.instance.invOpen = false;
        col1.text = "";
        col2.text = "";
        col3.text = "";
    }
}
