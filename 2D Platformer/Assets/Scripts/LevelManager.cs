﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {


    
    public PlayerController currentPlayer;

    //invincibility variable
    public bool invincible;

    //coin variables
    public int coinCount;
    public Text coinText;

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

    //death and respawn variables
    public GameObject deathAnim;
    public float respawnWaitTime;
    public ResetOnRespawn[] objectsToReset;
    public GameObject gameOverScreen;


    // Use this for initialization
    void Start () {
        currentPlayer = FindObjectOfType<PlayerController>();
        coinText.text = "Coins: " + coinCount;
        healthCount = maxHealth;
        currentLives = startingLives;
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
            currentPlayer.gameObject.SetActive(false);
            gameOverScreen.SetActive(true);
        }
        
    }

    public IEnumerator RespawnCo()
    {
        currentPlayer.gameObject.SetActive(false);
        Instantiate(deathAnim, currentPlayer.transform.position, currentPlayer.transform.rotation);

        yield return new WaitForSeconds(respawnWaitTime);

        healthCount = maxHealth;
        UpdateHeartMeter();
        coinCount = 0;
        coinText.text = "Coins: " + coinCount;

        currentPlayer.transform.position = currentPlayer.spawnPoint;
        currentPlayer.gameObject.SetActive(true);

        for(int i = 0; i < objectsToReset.Length; i++)
        {
            objectsToReset[i].gameObject.SetActive(true);
            objectsToReset[i].ResetObject();
        }
    }

    public void AddCoins(int coinsToAdd)
    {
        coinCount += coinsToAdd;
        coinText.text = "Coins: " + coinCount;
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

            currentPlayer.Knockback();

            if (healthCount <= 0)
            {
                Respawn();
            }
        }
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
