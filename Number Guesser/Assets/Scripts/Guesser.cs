using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guesser : MonoBehaviour {
    public int max;
    public int min;
    public int count;
    public int adjust;
    private int newMax;
    private int newMin;
    private int newCount;
    private int temp;
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
        print("If I get your number in ten guesses, I win. If I don't, you win.");
        NextGuess();
        max++;
    }

    private void NextGuess() {
        count--;
        adjust = Random.Range(-10, 10);
        temp = (min + max + adjust) / HALF;
        if (temp > max || temp < min || temp == guess) {
            NextGuess();
        }
        else {
            guess = temp;
            print("Is the number " + guess + "?");
        }
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
            print("**************************************");
            print("I have achieved victory. In your face!");
            print("**************************************");
            max = newMax;
            min = newMin;
            count = newCount;
            Start();
        }
        else if (count == 0)
        {
            print("****************************************************");
            print("I have brought shame to my circuits. In my face. T.T");
            print("****************************************************");
            max = newMax;
            min = newMin;
            count = newCount;
            Start();
        }
    }
}
