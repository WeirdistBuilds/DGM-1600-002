using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public float respawnWaitTime;
    public PlayerController currentPlayer;

    public GameObject deathAnim;

    public int coinCount;


	// Use this for initialization
	void Start () {
        currentPlayer = FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Respawn()
    {
        StartCoroutine("RespawnCo");
    }

    public IEnumerator RespawnCo()
    {
        currentPlayer.gameObject.SetActive(false);
        Instantiate(deathAnim, currentPlayer.transform.position, currentPlayer.transform.rotation);

        yield return new WaitForSeconds(respawnWaitTime);

        currentPlayer.transform.position = currentPlayer.spawnPoint;
        currentPlayer.gameObject.SetActive(true);
    }

    public void AddCoins(int coinsToAdd)
    {
        coinCount += coinsToAdd;
    }
}
