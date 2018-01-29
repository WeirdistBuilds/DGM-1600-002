using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Adventure : MonoBehaviour {
    //enum States
    public enum States { begin, living, kitchen, foyer, kidBathroom, frontYard, kidsRoom, yourRoom, yourBathroom, attic, hallway, backYard, death, ending };
    public States playerState;

    //text object
    public Text textObject;

    //timer
    public int timer;

    //room flags
    public bool livingFlag = false;
    public bool kitchenFlag = false;
    public bool foyerFlag = false;
    public bool kidBathroomFlag = false;
    public bool frontYardFlag = false;
    public bool kidsRoomFlag = false;
    public bool yourRoomFlag = false;
    public bool yourBathroomFlag = false;
    public bool atticFlag = false;
    public bool backYardFlag = false;


    //item flags
    public bool plunger = false;
    public bool antenna = false;
    public bool charger = false;


    // Use this for initialization
    void Start()
    {
        playerState = States.begin;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerState == States.begin)
        {
            Begin();
        }
        else if (playerState == States.living)
        {
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
        else if (playerState == States.hallway)
        {
            Hallway();
        }
        else if (playerState == States.kidBathroom)
        {
            KidBathroom();
        }
        else if (playerState == States.frontYard)
        {
            FrontYard();
        }
        else if (playerState == States.kidsRoom)
        {
            KidsRoom();
        }
        else if (playerState == States.yourRoom)
        {
            YourRoom();
        }
        else if (playerState == States.yourBathroom)
        {
            YourBathroom();
        }
        else if (playerState == States.attic)
        {
            Attic();
        }
        else if (playerState == States.backYard)
        {
            BackYard();
        }
        else if (playerState == States.ending)
        {
            Ending();
        }
        else if (playerState == States.death)
        {
            Death();
        }


    }


    private void Begin()
    {
        textObject.text = "*************\nATOMIC BOOGIE\n*************" +
            "\n\n" +
            "You are at home, watching the news, when the anchor confirms reports of detonations in LA and Washington. The nukes are coming! " +
            "You've got " + timer + " minutes to grab everything you need and retreat to the nuclear shelter you built in the backyard. " +
            "You will pick up and use items automatically.\n\n" +
            "Controls: N = north, S = south, E = east, W = west, U = up and D = down \n\n" +
            "Press B to begin.";

        // Set all starting conditions
        timer = 30;
        livingFlag = false;
        kitchenFlag = false;
        foyerFlag = false;
        frontYardFlag = false;
        kidsRoomFlag = false;
        yourRoomFlag = false;
        yourBathroomFlag = false;
        atticFlag = false;
        backYardFlag = false;
        plunger = false;
        charger = false;
        antenna = false;

        if (Input.GetKeyDown(KeyCode.B)) { playerState = States.living; }
    }


    private void Living()
    {
        if (timer <= 0)
        {
            playerState = States.death;
        }
        else
        {
            if (plunger == false && livingFlag == true) {
                textObject.text = "Living Room\n" +
               "You are in your mismatched, yet well furnished living room. " +
               "The news anchor is no longer at his seat on TV, replaced by what appears to be a teenaged intern reading poetry.\n\n" +
                "There are doors to the East, West and South. You have " + timer + " minutes remaining.";
            }
            else if (livingFlag == false)
            {
                textObject.text = "Living Room\n" +
                "You are in your mismatched, yet well furnished living room. " +
                "On a TV much too large to carry, the news anchor has removed his jacket and tie and appears to be drinking expensive scotch from the bottle. " +
                "Your phone is on the coffee table. You instinctively grab it.\n\n" +
                "There are doors to the East, West and South. You have " + timer + " minutes remaining.";
            }
            else if (livingFlag == true && charger == false)
            {
                textObject.text = "Living Room\n" + 
                "You are in your mismatched, yet well furnished living room. The news desk on TV is now empty, but you can see two people furiously making out in the background.\n\n" +
                "There are doors to the East, West and South. You have " + timer + " minutes remaining.";
            }
            else if (livingFlag == true && charger == true)
            {
                textObject.text = "Living Room\n" + 
                "You are in your mismatched, yet well furnished living room. On TV, some well-meaning production manager (or maybe the janitor) at your news station has loaded a YouTube " +
                "playlist to play instead of the empty news desk. It seems to be made up of performance art and German electro music.\n\n" +
                "There are doors to the East, West and South. You have " + timer + " minutes remaining.";
            }
            if (Input.GetKeyDown(KeyCode.W)) { playerState = States.foyer; timer--; livingFlag = true; }
            else if (Input.GetKeyDown(KeyCode.E)) { playerState = States.kitchen; timer--; livingFlag = true; }
            else if (Input.GetKeyDown(KeyCode.S)) { playerState = States.hallway; timer--; livingFlag = true; }
        }
    }


    private void Kitchen()
    {
        if (timer <= 0)
        {
            playerState = States.death;
        }
        else
        {
            textObject.text = "Kitchen\n" +
                "You feel a pang of sadness as you glance over your fully stocked kitchen, with a refrigerator full of comfort food " +
                "and cold, caffeinated beverages. All of your cabinets have been childproofed, but one drawer sits ajar.\n\n" +
                "There is a door to the West. You have " + timer + " minutes remaining.";
            if (kitchenFlag == false)
            {
                textObject.text = "Kitchen\n" +
                "You feel a pang of sadness as you glance over your fully stocked kitchen, with a refrigerator full of comfort food " +
                "and cold, caffeinated beverages. All of your cabinets have been childproofed, but one drawer sits ajar. " +
                "You can see a manual can opener inside. There is also a crank-flashlight on the fridge. You grab both items.\n\n" +
                "There is a door to the West. You have " + timer + " minutes remaining.";
            }
            if (Input.GetKeyDown(KeyCode.W)) { playerState = States.living; timer--; kitchenFlag = true; }
        }
    }


    private void Foyer()
    {
        if (timer <= 0)
        {
            playerState = States.death;
        }
        else
        {
            textObject.text = "Foyer\n" +
                "You have entered the foyer of your home, which is small and largely empty. A single brass coat rack sits just inside your front door.\n\n" +
                "There are doors to the North, South and East. You have " + timer + " minutes remaining.";
            if (foyerFlag == false)
            {
                textObject.text = "Foyer\n" +
                "You have entered the foyer of your home, which is small and largely empty. A single brass coat rack sits just inside your front door. " +
                "Two heavy winter coats hang on the coat rack here, despite it being the middle of June. You grab them both.\n\n" +
                "There are doors to the North, South and East. You have " + timer + " minutes remaining.";
            }
            if (Input.GetKeyDown(KeyCode.E)) { playerState = States.living; timer--; foyerFlag = true; }
            else if (Input.GetKeyDown(KeyCode.N)) { playerState = States.frontYard; timer--; foyerFlag = true; }
            else if (Input.GetKeyDown(KeyCode.S)) { playerState = States.kidBathroom; timer--; foyerFlag = true; }
        }
    }


    private void FrontYard()
    {
        if (timer <= 0)
        {
            playerState = States.death;
        }
        else
        {
            textObject.text = "Front Yard\n" +
                "You are standing in front of your house, watching the chaos unfold. " +
                "An old lady is battering an expressionless man with an heirloom bible. " +
                "You are still very relieved you told no one about your nuclear bunker. " +
                "Your old Subaru sits in the driveway, with all the windows smashed out and missing all four tires. It is now on fire. Oh dear.\n\n" +
                "There is a door to the South. Madness lies in all other directions. You have " + timer + " minutes remaining.";
            if (frontYardFlag == false)
            {
                textObject.text = "Front Yard\n" +
                "You are standing in front of your house, looking out at the grim mayhem that is ensuing outside. " +
                "The neighborhood has descended into a riot. You are immediately relieved you told no one about your nuclear bunker. " +
                "Your old Subaru sits in the driveway, with all the windows smashed out and two of the tires stolen. These savages! " +
                "A telescopic FM antenna is still attached to the hood. You take it. " +
                "There is a tool bag and a few bottles of motor oil in the trunk. You take these as well. " +
                "Finally, there is a package on your porch. These must be the hazmat suits you ordered. What luck! You also take these.\n\n" +
                "There is a door to the South. The remaining directions are a panic of fire, blood, screaming and speeding vehicles. You have " + timer + " minutes remaining.";
                antenna = true;
            }
            if (Input.GetKeyDown(KeyCode.S)) { playerState = States.foyer; timer--; frontYardFlag = true; }
        }
    }


    private void KidBathroom()
    {
        if (timer <= 0)
        {
            playerState = States.death;
        }
        else
        {
            if (charger == true)
            {
                textObject.text = "Kid's Bathroom\n" +
                "You are in a bathroom that exists solely for your kid to use, and it hasn't been cleaned for months. A wet towel sits on the floor because they " +
                "clogged the toilet (with your phone charger) and didn't bother to tell you.\n\n" +
                "There is a door to the North. You have " + timer + " minutes remaining.";
                if (Input.GetKeyDown(KeyCode.N)) { playerState = States.foyer; timer--; }
            }
            else if (plunger == true)
            {
                textObject.text = "Kid's Bathroom\n" +
                "This room exists solely for your kid to use, and it hasn't been cleaned for months. A wet towel sits on the floor because they " +
                "apparently clogged the toilet and didn't bother to tell you. " +
                "Using the plunger, you unclog the toilet. Your (hopefully waterproof) charger comes bobbing to the surface. You grab it. Your kid is an idiot.\n\n" +
                "There is a door to the North. You have " + timer + " minutes remaining.";
                if (Input.GetKeyDown(KeyCode.N)) { playerState = States.foyer; timer--; charger = true; }
            }
            else
            {
                textObject.text = "Kid's Bathroom\n" +
                "You are in a bathroom that exists solely for your kid to use, and it hasn't been cleaned for months. A wet towel sits on the floor because they " +
                "apparently clogged the toilet and didn't bother to tell you.\n\n" +
                "There is a door to the North. You have " + timer + " minutes remaining.";
                if (Input.GetKeyDown(KeyCode.N)) { playerState = States.foyer; timer--; }
            }
            
        }
    }


    private void Hallway()
    {
        if (timer <= 0)
        {
            playerState = States.death;
        }
        else
        {
            textObject.text = "Hallway\n" +
                "You are in the only hallway in your house. There is a hamper here, overflowing with dirty laundry. Regardless of the outcome of your adventure " +
                "here, this cache of clothing is used as raw materials for the bedding of Krothnar the Robot Smasher in about 200 years.\n\n" +
                "There are doors to the North, South, East, and West. You have " + timer + " minutes remaining.";
            if (Input.GetKeyDown(KeyCode.N)) { playerState = States.living; timer--; }
            else if (Input.GetKeyDown(KeyCode.S)) { playerState = States.backYard; timer--; }
            else if (Input.GetKeyDown(KeyCode.E)) { playerState = States.yourRoom; timer--; }
            else if (Input.GetKeyDown(KeyCode.W)) { playerState = States.kidsRoom; timer--; }
        }
    }


    private void KidsRoom()
    {
        if (timer <= 0)
        {
            playerState = States.death;
        }
        else
        {
            textObject.text = "Kid's Bedroom\n" +
                "Your kid is an unholy terror, and it is evidenced by the mess that is their room. The walls are covered with color printed pictures of " +
                "bands you've never heard of, which explains where all the ink goes every week. Their bed is unmade, and sits next to a pile of foul trash. " +
                "underneath this horrible pile of cans and greasy paper plates lives an overwhelmed garbage can.\n\n" +
                "There is a door to the East. You have " + timer + " minutes remaining.";
            if (kidsRoomFlag == false)
            {
                textObject.text = "Kid's Bedroom\n" +
                "Your kid is an unholy terror, and it is evidenced by the mess that is their room. The walls are covered with color printed pictures of " +
                "bands you've never heard of, which explains where all the black ink goes every week. Their bed is unmade, and sits next to a pile of foul trash. " +
                "Underneath this horrible pile of cans and greasy paper plates lives an overwhelmed garbage can. " +
                "There is a small flatscreen TV here, which you wade through the filth to take.\n\n" +
                "There is a door to the East. You have " + timer + " minutes remaining.";
            }
            if (Input.GetKeyDown(KeyCode.E)) { playerState = States.hallway; kidsRoomFlag = true; timer--; }
        }
    }


    private void YourRoom()
    {
        if (timer <= 0)
        {
            playerState = States.death;
        }
        else
        {
            if (yourRoomFlag == false && antenna == false)
            {
                textObject.text = "Your Bedroom\n" +
                "You are in your bedroom. You don't yet know how badly you will miss your memory foam matress. " +
                "A door to the attic is above you, but the string to open it broke off a month ago. You will need something long to open it. " +
                "Since you've seen this coming for a while, you have slept next to loaded shotgun for months. " +
                "In the course of your research, you've taped a city utility map to the wall. " +
                "There is also a portable hand-crank radio next to your bed. You grab all three of these items.\n\n" +
                "There are doors to the East and West. You have " + timer + " minutes remaining.";
            }
            else if (yourRoomFlag == true && antenna == false)
            {
                textObject.text = "Your Bedroom\n" +
                "You are in your bedroom. You don't yet know how badly you will miss your memory foam matress. " +
                "A small door to the attic is above you, but the string to open it broke off a month ago. You will need something long to open it.\n\n" +
                "There are doors to the East and West. You have " + timer + " minutes remaining.";
            }
            else if (yourRoomFlag == false && antenna == true)
            {
                textObject.text = "Your Bedroom\n" +
                "You are in your bedroom. You don't yet know how badly you will miss your memory foam matress. " +
                "A small door to the attic is above you, but the string to open it broke off a month ago. Reaching up with your car's antenna, " +
                "you snag the handle and pull it down. A wooden ladder unfolds as you open the hatch. " +
                "Since you've seen this coming for a while, you have slept next to loaded shotgun for months. " +
                "In the course of your research, you've taped a city utility map to the wall. " +
                "There is also a portable hand-crank radio next to your bed. You grab all three of these items.\n\n" +
                "There are doors to the East, West, and Up. You have " + timer + " minutes remaining.";
            }
            else if (yourRoomFlag == true && antenna == true)
            {
                textObject.text = "Your Bedroom\n" +
                "You are in your bedroom. You don't yet know how badly you will miss your memory foam matress. " +
                "A small door to the attic is above you, but the string to open it broke off a month ago. Reaching up with your car's antenna, " +
                "you snag the handle and pull it down. A wooden ladder unfolds as you open the hatch.\n\n" +
                "There are doors to the East, West, and Up. You have " + timer + " minutes remaining.";
            }
            if (Input.GetKeyDown(KeyCode.E)) { playerState = States.yourBathroom; yourRoomFlag = true; timer--; }
            else if (Input.GetKeyDown(KeyCode.W)) { playerState = States.hallway; yourRoomFlag = true; timer--; }
            else if (Input.GetKeyDown(KeyCode.U) && antenna == true) { playerState = States.attic; yourRoomFlag = true; timer--; }
        }
    }


    private void Attic()
    {
        if (timer <= 0)
        {
            playerState = States.death;
        }
        else
        {
            textObject.text = "Attic\n" +
                "Here lies your childhood possessions, packed up poorly in ragged cardboard boxes. One of the boxes sits open.\n\n" +
                "There is a door leading Down. You have " + timer + " minutes remaining.";
            if (atticFlag == false)
            {
                textObject.text = "Attic\n" +
                "Here lies your childhood possessions, packed up poorly in ragged cardboard boxes. One of the boxes sits open. " +
                "A gleaming Super Nintendo lay dormant inside, next to a grocery bag containing copies of Super Metroid, A Link to the Past, Sim City, and Street Fighter 2. You do not hesitate to take these precious gems. " +
                "The HVAC is also up here, and a box of expensive air filters sits near to it because on top of everything else, your kid is allergic to pollen. It also occurs to you to grab these as well.\n\n" +
                "There is a door leading Down. You have " + timer + " minutes remaining.";
            }
            if (Input.GetKeyDown(KeyCode.D)) { playerState = States.yourRoom; atticFlag = true; timer--; }
        }
    }


    private void YourBathroom()
    {
        if (timer <= 0)
        {
            playerState = States.death;
        }
        else
        {
            textObject.text = "Your Bathroom\n" +
                "You are in your pristine bathroom, with polished brass taps and alabaster utilities. It's all lemon scented, and you are going to miss it terribly.\n\n" +
                "There is a door to the West. You have " + timer + " minutes remaining.\n";
            if (yourBathroomFlag == false)
            {
                textObject.text = "Your Bathroom\n" +
                "You are in your pristine bathroom, with polished brass taps and alabaster utilities. It's all lemon scented, and you are going to miss it terribly. " +
                "There is a toilet plunger next to your throne, and potassium iodide tablets in the medicine cabinet. You take them both.\n\n" +
                "There is a door to the West. You have " + timer + " minutes remaining.";
                plunger = true;
            }
            if (Input.GetKeyDown(KeyCode.W)) { playerState = States.yourRoom; yourBathroomFlag = true; timer--; }
        }
    }

    private void BackYard()
    {
        if (timer <= 0)
        {
            playerState = States.death;
        }
        else
        {
            textObject.text = "Backyard\n" +
                "You are back in your backyard. Your green, lush, verdant, soon to be destroyed backyard. " +
                "Your kid is now anxiously moving back and forth with anticipation. Their face is a mask of fear. " +
                "If you've grabbed all the things you think you will need, you had better descend!\n\n" +
                "There is a door to the North and another leading Down. You have " + timer + " minutes remaining.";
            if (backYardFlag == false)
            {
                textObject.text = "Backyard\n" +
                "You are now in your backyard, which you took care of meticulously after working late at night to secretly install a working nuclear bunker. " +
                "Your kid is visibly weeping while clutching a pile of blankets. They are begging you with their eyes to climb down to safety with them. " +
                "If you've grabbed all the things you think you will need, you had better descend!\n\n" +
                "There is a door to the North and another leading Down. You have " + timer + " minutes remaining.";
            }
            if (Input.GetKeyDown(KeyCode.N)) { playerState = States.hallway; backYardFlag = true; timer--; }
            if (Input.GetKeyDown(KeyCode.D)) { playerState = States.ending; }
        }
    }


    private void Death()
    {
        textObject.text = "ESCAPE FAILED\n\n" +
            "With your arms full of items you believed would help you survive the oncoming nuclear winter, you forgot to keep track of the bombs that were coming to cause it. " +
            "As high-yield nuclear warheads began to rain down on your frantic suburb, you raced to the back door. Through the glass, you watched as your kid closed the hatch, leaving you to your final conflagration. " +
            "Maybe your kid is smarter than you thought. Smarter than you, anyway.\n\n" +
            "YOUR FABLE ENDS HERE.\n\n" +
            "Press R to restart from the beginning.";
        if (Input.GetKeyDown(KeyCode.R)) { playerState = States.begin; }

    }

    private void Ending()
    {
        int finalScore = ScoreCalc();
        if (finalScore <= 10)
        {
            textObject.text = "ESCAPE COMPLETE\n\n" +
                "The story you will tell your child time and time again boils down to just one sentence: you panicked. With your bunker woefully underequipped to sustain itself for long, your kid began to resent you for " +
                "leaving behind such important things. Until the day you died, you struggled to keep your small island of life afloat in the sea of radiation that was only a few dozen feet above you. As such, you could never leave. " +
                "One day, after many decades of this struggle, your kid announced they were going to take their chances in the wastes. You watched them ascend the ladder, got one last glimpse of sunlight, and never saw another human being again.\n\n" +
                "Your final score was " + finalScore + " out of 20.\n\n" +
                "Press R to restart from the beginning.";
        }
        else if (finalScore <= 19)
        {
            textObject.text = "ESCAPE COMPLETE\n\n" +
                "While you descend the ladder to the relative safety of your bunker, a few items you wished you had grabbed occur to you. As the years go by in the comfort and safety of your bunker, you marvel at how much those few items bother you. " +
                "After all, your kid is incredibly happy here, it would seem that the destruction of their school and certain bands gave them immense relief. You both took care of yourself and each other, and even popped up into the wasteland occasionally " +
                "to scavenge materials and supplies. In time, you met other people and joined a kind of loose colony amongst the survivors. Lately, there's been talk of a growing band of cannibals operating nearby. You're sure it'll be fine though.... \n\n" +
                "Your final score was " + finalScore + " out of 20.\n\n" +
                "Press R to restart from the beginning.";
        }
        else if (finalScore >= 20)
        {
            textObject.text = "On the day that your kid rose up with the other survivors against the Red Circle, and valiantly saved twenty orphans from becoming someone's dinner, they found themselves unanimously elected the leader of your ragged band. " +
                "In time they taught the people about the intricate utility network buried underground using your map. They taught people how to build sustainable civilizations, recalling their time playing Sim City. They single handedly fed the entire " +
                "group by retrieving stores of canned goods from a bombed grocery basement, and handed out open cans to their army of loyal orphans. They even treated the masses to your music, perhaps the only respectable library left in existence, " +
                "from your phone. In each of these cases, and many others, your kid spoke about your clear thinking under pressure, and hoped that they could impart such poise, such grace, such panache to these people. Their people.\n\n" +
                "~The End~\n\n" +
                "Your final score was " + finalScore + " out of 20.\n\n" +
                "Press R to restart from the beginning.";
        }
            
        if (Input.GetKeyDown(KeyCode.R)) { playerState = States.begin; }
    }
        

    private int ScoreCalc()
    {
        int score = 0;
        if (livingFlag == true) { score += 1; }
        if (kitchenFlag == true) { score += 2; }
        if (foyerFlag == true) { score += 2; }
        if (charger == true) { score += 1; }
        if (frontYardFlag == true) { score += 3; }
        if (kidsRoomFlag == true) { score += 1; }
        if (yourRoomFlag == true) { score += 3; }
        if (yourBathroomFlag == true) { score += 1; }
        if (atticFlag == true) { score += 6; }
        //possible total 20
        return score;
    }
}
