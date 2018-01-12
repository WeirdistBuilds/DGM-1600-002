using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guesser : MonoBehaviour {
    
	// Use this for initialization
	private void Start () {
        int max = 1000;
        int min = 1;
        int half = 2;
        int guess;

        print("Welcome to Number Guesser!");
        print ("Pick a number between " + min + " and " + max + " inclusive.");

        guess = max / half;

        // Is the value var guess?
        print("Is the value " + guess + "?");
        // Instructions
        print("Press the up arrow for higher, press the down arrow for lower, and hit enter if I got it!");
	}
	
	// Update is called once per frame
	public void Update () {
        
	}
}
