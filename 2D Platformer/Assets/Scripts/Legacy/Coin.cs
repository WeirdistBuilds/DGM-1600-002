using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

    private LevelManager theLevelManager;
    public int bonusAtCoinCount;
    public int coinValue;
    public int livesAtBonus;

	// Use this for initialization
	void Start () {
        theLevelManager = FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            theLevelManager.AddBlood(coinValue);
            if (theLevelManager.bloodCount >= bonusAtCoinCount)
            {
                theLevelManager.AddBlood(-bonusAtCoinCount);
                theLevelManager.AddLives(livesAtBonus);

            }
            gameObject.SetActive(false);
        }
        

    }
}
