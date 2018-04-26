using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {


    
    public PlayerController thePlayer;

    //invincibility variable
    public bool invincible;

    //pickup variables
    public int bloodCount;
    public Text bloodText;
    public AudioSource blood1Sound;
    public AudioSource blood5Sound;
    public AudioSource lifeSound;
    public AudioSource heartSound;
    public AudioSource checkpointSound;

    //health variables
    public Image heart1;
    public Image heart2;
    public Image heart3;
    public Sprite heartFull;
    public Sprite heartHalf;
    public Sprite heartEmpty;
    public int maxHealth;
    public int healthCount;

    //life variables
    public int currentLives;
    public int startingLives;
    public Text livesText;

    //music
    public AudioSource levelMusic;
    public AudioSource gameOverMusic;
    public AudioSource levelCompleteMusic;
    public AudioSource bossMusic;
    public AudioSource endingMusic;

    //death and respawn variables
    public GameObject deathAnim;
    public float respawnWaitTime;
    public ResetOnRespawn[] objectsToReset;
    public GameObject gameOverScreen;
    public bool respawnCoActive;


    // Use this for initialization
    void Start () {
        thePlayer = FindObjectOfType<PlayerController>();
        healthCount = maxHealth;
        
        //carry blood over or not
        if(PlayerPrefs.HasKey("BloodCount"))
        {
            bloodCount = PlayerPrefs.GetInt("BloodCount");
        }
        bloodText.text = "Blood: " + bloodCount;

        //carry lives over or not
        if(PlayerPrefs.HasKey("CurrentLives"))
        {
            currentLives = PlayerPrefs.GetInt("CurrentLives");
        }
        else
        {
            currentLives = startingLives;
        }
        livesText.text = "x " + currentLives;

        objectsToReset = FindObjectsOfType<ResetOnRespawn>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Respawn()
    {
        currentLives -= 1;
        livesText.text = "x " + currentLives;

        if(currentLives > 0)
        {
            StartCoroutine("RespawnCo");
        }
        else
        {
            thePlayer.gameObject.SetActive(false);
            gameOverScreen.SetActive(true);
            levelMusic.Stop();
            gameOverMusic.Play();
        }
        
    }

    public IEnumerator RespawnCo()
    {
        respawnCoActive = true;

        thePlayer.gameObject.SetActive(false);
        Instantiate(deathAnim, thePlayer.transform.position, thePlayer.transform.rotation);

        yield return new WaitForSeconds(respawnWaitTime);

        respawnCoActive = false;

        healthCount = maxHealth;
        UpdateHeartMeter();
        bloodCount = 0;
        bloodText.text = "Blood: " + bloodCount;

        thePlayer.transform.position = thePlayer.spawnPoint;
        thePlayer.gameObject.SetActive(true);

        for(int i = 0; i < objectsToReset.Length; i++)
        {
            objectsToReset[i].gameObject.SetActive(true);
            objectsToReset[i].ResetObject();
        }
    }

    public void AddBlood(int bloodToAdd)
    {
        bloodCount += bloodToAdd;
        bloodText.text = "Blood: " + bloodCount;
    }

    public void AddLives(int livesToAdd)
    {
        currentLives += livesToAdd;
        livesText.text = "x " + currentLives;
    }

    public void HurtPlayer(int damageToTake)
    {
        if (!invincible)
        {
            healthCount -= damageToTake;
            UpdateHeartMeter();

            thePlayer.Knockback();
            thePlayer.hurtSound.Play();
            if (healthCount <= 0)
            {
                Respawn();
            }
        }
    }

    public void GiveHealth(int healthToGive)
    {
        healthCount += healthToGive;

        if (healthCount > maxHealth)
        {
            healthCount = maxHealth;
        }

        UpdateHeartMeter();
    }

    public void UpdateHeartMeter()
    {
        switch(healthCount)
        {
            case 6: heart1.sprite = heartFull; heart2.sprite = heartFull; heart3.sprite = heartFull; return;
            case 5: heart1.sprite = heartFull; heart2.sprite = heartFull; heart3.sprite = heartHalf; return;
            case 4: heart1.sprite = heartFull; heart2.sprite = heartFull; heart3.sprite = heartEmpty; return;
            case 3: heart1.sprite = heartFull; heart2.sprite = heartHalf; heart3.sprite = heartEmpty; return;
            case 2: heart1.sprite = heartFull; heart2.sprite = heartEmpty; heart3.sprite = heartEmpty; return;
            case 1: heart1.sprite = heartHalf; heart2.sprite = heartEmpty; heart3.sprite = heartEmpty; return;
            case 0: heart1.sprite = heartEmpty; heart2.sprite = heartEmpty; heart3.sprite = heartEmpty; return;
            default: heart1.sprite = heartEmpty; heart2.sprite = heartEmpty; heart3.sprite = heartEmpty; return;


        }
    }
}
