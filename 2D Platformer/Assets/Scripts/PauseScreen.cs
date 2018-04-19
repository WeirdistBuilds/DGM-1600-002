﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour {

    public string levelSelect;
    public string mainMenu;

    private LevelManager theLevelManager;
    private PlayerController thePlayer;
    public GameObject thePauseScreen;

	// Use this for initialization
	void Start () {
        theLevelManager = FindObjectOfType<LevelManager>();
        thePlayer = FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Pause"))
        {
            if(Time.timeScale == 0)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
	}

    public void PauseGame()
    {
        Time.timeScale = 0;

        thePauseScreen.SetActive(true);
        thePlayer.canMove = false;
        theLevelManager.levelMusic.Pause();
    }

    public void ResumeGame()
    {
        thePauseScreen.SetActive(false);
        Time.timeScale = 1f;
        thePlayer.canMove = true;
        theLevelManager.levelMusic.Play();
    }

    public void LevelSelect()
    {
        PlayerPrefs.SetInt("CurrentLives", theLevelManager.currentLives);
        PlayerPrefs.SetInt("CoinCount", theLevelManager.bloodCount);
        Time.timeScale = 1f;
        SceneManager.LoadScene(levelSelect);
    }

    public void QuitToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(mainMenu);
    }
}
