using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string name;
    public string[] sentences;

    public void setUsedMessage() {
        sentences = new string[] {sentences[sentences.Length - 1]};
        Debug.Log(sentences[0]);
    }
    
}
