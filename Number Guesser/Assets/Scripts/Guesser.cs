using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guesser : MonoBehaviour {
    public int max;
    public int min;
    public int count;
    private int newMax;
    private int newMin;
    private int newCount;
    public const int HALF = 2;
    private int guess;
    // Use this for initialization
    private void Start () {
        //Intro Dialogue
        newMax = max;
        newMin = min;
        newCount = count;
        print("Welcome to Number Guesser!");
        print ("Pick a number between " + (min) + " and " + (max) + " inclusive.");
        
        // Instructions
        print("Press the up arrow for higher, press the down arrow for lower, and hit enter if I got it!");
        NextGuess();
        max++;
    }

    private void NextGuess() {
        count--;
        guess = (min + max) / HALF;
        print("Is the number " + guess + "?");
    }
	
	// Update is called once per frame
	void Update () {
        // Press Up Key
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            min = guess;
            NextGuess();
        }
        // Press Down Key
        else if (Input.GetKeyDown(KeyCode.DownArrow)) {
            max = guess;
            NextGuess();
        }
        // Press Return
        else if (Input.GetKeyDown(KeyCode.Return)) {
            print("I have achieved victory. In your face.\n\n\n");
            max = newMax;
            min = newMin;
            count = newCount;
            Start();
        }
        else if (count == 0)
        {
            print("I have brought shame to my circuits. In my face. T.T\n\n\n");
            max = newMax;
            min = newMin;
            count = newCount;
            Start();
        }
    }
}
