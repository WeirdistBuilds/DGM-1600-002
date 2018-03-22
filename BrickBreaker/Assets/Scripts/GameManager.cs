using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static int currentLevel;
    public static int brickCount;

    public static GameManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<GameManager>();
                DontDestroyOnLoad(_instance.gameObject);
            }

            return _instance;
        }
    }

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            if (this != _instance)
                Destroy(this.gameObject);
        }
    }

    public void SceneLoader(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void IncreaseLevel()
    {
        currentLevel++;
    }

    public void StartGame()
    {
        currentLevel = 2;
        SceneManager.LoadScene(currentLevel);
        Debug.Log("Load Build Index " + currentLevel);
    }

    public void LoadNextLevel()
    {
        brickCount = 0;
        Debug.Log("Load Build Index " + currentLevel);
        SceneManager.LoadScene(currentLevel);
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }

    public void AddBrick()
    {
        brickCount++;
    }

    public void MinusBrick()
    {
        brickCount--;
    }

    public int GetBrickCount()
    {
        return brickCount;
    }

}
