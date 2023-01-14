using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingTextManager : MonoBehaviour
{
    public GameObject textContainer;
    public GameObject textPrefab;

    private List<FloatingText> floatingTexts = new List<FloatingText>();

    private void Update() {
        foreach(FloatingText txt in floatingTexts) {
            txt.UpdateFloatingText();
        }
    }

    // set the values in floating text and show it
    public void Show(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration) {
        FloatingText floatingText = GetFloatingText();

        floatingText.txt.text = msg;
        floatingText.txt.fontSize = fontSize;
        floatingText.txt.color = color;
        floatingText.go.transform.position = Camera.main.WorldToScreenPoint(position);  // transfer world space to screen space so we can use it in the UI
                                                                                        // note: make sure camera is tagged as main camera
        floatingText.motion = motion;
        floatingText.duration = duration;

        floatingText.Show();
    }

    private FloatingText GetFloatingText() {
        FloatingText txt = floatingTexts.Find(t => !t.active); // find an inactive FloatingText object
                                                               // this syntax is a shortened version of a for loop
        // properly initialize and add a new FloatingText object if none is available in the list
        if (txt == null) {
            txt = new FloatingText();
            txt.go = Instantiate(textPrefab); // create new game object, assign to txt.go
            txt.go.transform.SetParent(textContainer.transform);
            txt.txt = txt.go.GetComponent<Text>();

            floatingTexts.Add(txt);
        }

        return txt;
    }
}
