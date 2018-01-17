using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guesser : MonoBehaviour {
    public int max = 1000;
    public int min = 1;
    public int half = 2;
    public int guess;
    // Use this for initialization
    private void Start () {
        
        print("Welcome to Number Guesser!");
        print ("Pick a number between " + min + " and " + max + " inclusive.");
        
        // Is the value var guess?
        print("Is the number " + guess + "?");
        // Instructions
        print("Press the up arrow for higher, press the down arrow for lower, and hit enter if I got it!");
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            min = guess;
            guess = (min + max) / half;
            print("Is the number " + guess + "?");
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            max = guess;
            guess = (min + max) / half;
            print("Is the number " + guess + "?");
        }
        if (Input.GetKeyDown(KeyCode.Return)) {
            print("Nice.");
        }
    }
}
