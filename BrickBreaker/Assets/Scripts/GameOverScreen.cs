using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour {

    private void Restart()
    {
        FindObjectOfType<GameManager>().SceneLoader(1);
    }
}
