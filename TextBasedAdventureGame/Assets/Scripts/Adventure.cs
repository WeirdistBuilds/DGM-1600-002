using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adventure : MonoBehaviour {
    //enum States
    public enum States {living, kitchen, foyer};
    public States playerState;

    //timer
    public int timer = 30;


    //room flags
    public bool livingFlag = false;
    public bool kitchenFlag = false;
    public bool foyerFlag = false;
     


	// Use this for initialization
	void Start () {
        print("NUKE ESCAPE \n" +
            "The end hath come and you need to run! \n" +
            "According to the nice man on the news, the nukes are coming. \n" +
            "You've got thirty minutes to grab everything you need \n" +
            "and retreat to the bomb shelter you built in the backyard. \n" +
            "\n" +
            "You will pick things up automatically, but you move with \n" +
            "N = north, S = south, E = east, W = west, U = up and D = down \n" +
            "\n");
        playerState = States.living;
	}
	
	// Update is called once per frame
	void Update () {
        if (playerState == States.living) {
            Living();
        }
        else if (playerState == States.kitchen)
        {
            Kitchen();
        }
        else if (playerState == States.foyer)
        {
            Foyer();
        }
		
	}
    private void Living() {
        if (timer == 0)
        {
            print("You dead!");
        }
        else
        {
            print("The apocalypse proceedings are on TV.");
            if (livingFlag == false)
            {
                print("You grab your phone off of the coffee table.");
            }
            print("There are doors to the East and West.");
            livingFlag = true;
            timer--;
            if (Input.GetKeyDown(KeyCode.W)) { playerState = States.foyer; }
            if (Input.GetKeyDown(KeyCode.E)) { playerState = States.kitchen; }
        }
    }
    private void Kitchen()
    {
        if (timer == 0)
        {
            print("You dead!");
        }
        else
        {
            print("You're in the kitchen.");
            if (kitchenFlag == false)
            {
                print("You grab a crank flashlight from on top of the fridge. /n");
                print("You grab a manual can opener from the drawer. /n");
            }
            print("There are doors to the East and West.");
            kitchenFlag = true;
            timer--;
            if (Input.GetKeyDown(KeyCode.W)) { playerState = States.living; }
        }
    }
    private void Foyer()
    {
        if (timer == 0)
        {
            print("You dead!");
        }
        else
        {
            print("You are in the foyer.");
            if (kitchenFlag == false)
            {
                print("You grab your winter gear from the coatrack. /n");
                print("You grab your kid's winter gear from the coatrack. /n");
            }
            print("There are doors to the North and West.");
            foyerFlag = true;
            timer--;
            if (Input.GetKeyDown(KeyCode.E)) { playerState = States.living; }
        }
    }
}
