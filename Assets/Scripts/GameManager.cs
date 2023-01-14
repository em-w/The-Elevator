using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    public static GameManager instance;
    // awake initializes stuff before the game starts
    private void Awake() {

        // if there is already a GameManager in the game, don't make a new one
        if (GameManager.instance != null) {
            Destroy(gameObject);
            return;
        }
        instance = this;
        SceneManager.sceneLoaded += LoadState; // calls LoadState when scene is loaded
        DontDestroyOnLoad(gameObject); // ensures that GameManager remains intact throughout all the scenes
    }


    // references
    //public Player player;
    //public FloatingTextManager floatingTextManager;

    // logic
    public bool speaking = false;
    public bool invOpen = false;

    // things to keep track of
    public List<string> inventory;
    public int cassette1Taken = 0;
    public int beetleTaken = 0;
    public int matchesTaken = 0;
    public int ironKeyTaken = 0;
    public int birdPhase = 0;
    public int isLit = 0;
    public int waxTaken = 0;
    public int waxed = 0;
    public int cKeyAndGemTaken = 0;
    public int paintingPhase = 0;
    public int silverKeyTaken = 0;
    public int vaseOpen = 0;
    public int goldKeyTaken = 0;
    public int mirrShattered = 0;
    public int shardTaken = 0;
    public int gUnlocked = 0;
    public int sUnlocked = 0;
    public int iUnlocked = 0;
    public int cUnlocked = 0;
    public int elevatorOpen = 0;

    public void SaveState() {
        
        string s = "";

        if (inventory.Count != 0) {
            for (int i = 0; i < (inventory.Count - 1); i++) {
                s += inventory[i] + ",";
            }

            s += inventory[inventory.Count - 1];
        }
        
        s += "|" + cassette1Taken;
        s += "|" + beetleTaken;
        s += "|" + matchesTaken;
        s += "|" + ironKeyTaken;
        s += "|" + birdPhase;
        s += "|" + isLit;
        s += "|" + waxTaken;
        s += "|" + waxed;
        s += "|" + cKeyAndGemTaken;
        s += "|" + paintingPhase;
        s += "|" + silverKeyTaken;
        s += "|" + vaseOpen;
        s += "|" + goldKeyTaken;
        s += "|" + mirrShattered;
        s += "|" + shardTaken;
        s += "|" + gUnlocked;
        s += "|" + sUnlocked;
        s += "|" + iUnlocked;
        s += "|" + cUnlocked;
        s += "|" + elevatorOpen;
 
        PlayerPrefs.SetString("SaveState", s);

        Debug.Log("Saved!");

    }

    public void LoadState(Scene s, LoadSceneMode mode) {

        Debug.Log("Loaded");
        if (!PlayerPrefs.HasKey("SaveState")) {
            return;
        }

        string[] data = PlayerPrefs.GetString("SaveState").Split('|');

        string[] inv = data[0].Split(',');
        inventory.Clear();
        foreach (string str in inv) {
            inventory.Add(str);
        }

        inventory.Remove("");
        
        

        cassette1Taken = int.Parse(data[1]);
        beetleTaken = int.Parse(data[2]);
        matchesTaken = int.Parse(data[3]);
        ironKeyTaken = int.Parse(data[4]);
        birdPhase = int.Parse(data[5]);
        isLit = int.Parse(data[6]);
        waxTaken = int.Parse(data[7]);
        waxed = int.Parse(data[8]);
        cKeyAndGemTaken = int.Parse(data[9]);
        paintingPhase = int.Parse(data[10]);
        silverKeyTaken = int.Parse(data[11]);
        vaseOpen = int.Parse(data[12]);
        goldKeyTaken = int.Parse(data[13]);
        mirrShattered = int.Parse(data[14]);
        shardTaken = int.Parse(data[15]);
        gUnlocked = int.Parse(data[16]);
        sUnlocked = int.Parse(data[17]);
        iUnlocked = int.Parse(data[18]);
        cUnlocked = int.Parse(data[19]);
        elevatorOpen = int.Parse(data[20]);
    }

    public bool AddToInv(string item) {
        if (inventory.Count == 9) {
            return false;
        } else {
            inventory.Add(item);
            return true;
        }
    }

    public void TakeCassette1() {
        cassette1Taken = 1;
    }

    public void TakeBeetle() {
        beetleTaken = 1;
    }

    public void TakeMatchesAndIKey() {
        ironKeyTaken = 1;
        matchesTaken = 1;
    }

}
