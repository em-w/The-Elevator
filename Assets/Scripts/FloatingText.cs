using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingText
{
    public bool active;
    public GameObject go;
    public Text txt;
    public Vector3 motion;
    public float duration;
    public float lastShown;
    public void Show() {
        active = true;
        lastShown = Time.time;
        go.SetActive(active);
    }

    public void Hide() {
        active = false;
        go.SetActive(active);
    }

    public void UpdateFloatingText() {
        if(!active) {
            return;
            //don't do anything if inactive
        }

        // if text times out of duration
        if (Time.time - lastShown > duration) {
            Hide();
        }

        // transform text
        go.transform.position += motion * Time.deltaTime;
            
    }
}
