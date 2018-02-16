using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryBottom : MonoBehaviour {

    public GameManager theGameManager;

    

    void Start () {
        theGameManager = FindObjectOfType<GameManager>();
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("gameover");
        theGameManager.LoadLevel("GameOver");
    }
}
