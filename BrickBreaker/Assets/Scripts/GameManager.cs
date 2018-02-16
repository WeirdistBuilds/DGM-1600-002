using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;


    void Awake()
    {
        if (instance == null)                           // if instance is not assigned, assign to this object
        {
            instance = this;
        }
        else if (instance != this)                       // if instance doesn't equal this, destroy this
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);             // don't destroy on load

    }

    public void LoadLevel(string level)
    {
        SceneManager.LoadScene(level);
    }
}
