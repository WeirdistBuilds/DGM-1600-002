using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public string firstLevel;
    public string levelSelect;

    public string[] levelNames;

    public int startingLives;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void NewGame()
    {
        SceneManager.LoadScene(levelSelect);
        for (int i = 0; i < levelNames.Length; i++)
        {
            PlayerPrefs.SetInt(levelNames[i], 0);
        }

        PlayerPrefs.SetInt("BloodCount", 0);
        PlayerPrefs.SetInt("CurrentLives", 3);
        PlayerPrefs.SetInt("EndCoin", 0);
    }

    public void Continue()
    {
        SceneManager.LoadScene(levelSelect);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }
}
