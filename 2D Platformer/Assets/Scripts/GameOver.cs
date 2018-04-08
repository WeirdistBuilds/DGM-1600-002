using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    public string levelSelect;
    public string mainMenu;

    private LevelManager theLevelManager;

	// Use this for initialization
	void Start () {
        theLevelManager = FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Restart()
    {
        ResetCoinsLives();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LevelSelect()
    {
        ResetCoinsLives();
        SceneManager.LoadScene(levelSelect);
    }

    public void QuitToMainMenu()
    {
        SceneManager.LoadScene(mainMenu);
    }

    public void ResetCoinsLives()
    {
        PlayerPrefs.SetInt("CoinCount", 0);
        PlayerPrefs.SetInt("CurrentLives", theLevelManager.startingLives);
    }
}
