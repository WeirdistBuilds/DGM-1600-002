using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelEnd : MonoBehaviour {

    public string levelToLoad;
    public string levelToUnlock;

    private PlayerController thePlayer;
    private CameraController theCamera;
    private LevelManager theLevelManager;

    public Sprite skullTaken;
    private SpriteRenderer skullSpriteRenderer;

    public float waitToMove;
    public float waitToLoad;
    private bool movePlayer;

	// Use this for initialization
	void Start () {
        thePlayer = FindObjectOfType<PlayerController>();
        theCamera = FindObjectOfType<CameraController>();
        theLevelManager = FindObjectOfType<LevelManager>();
        skullSpriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if(movePlayer)
        {
            thePlayer.playerRigidBody.velocity = new Vector3(thePlayer.moveSpeed, thePlayer.playerRigidBody.velocity.y, 0f);
        }
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            //SceneManager.LoadScene(levelToLoad);
            skullSpriteRenderer.sprite = skullTaken;
            StartCoroutine("LevelEndCo");
        }
    }

    public IEnumerator LevelEndCo()
    {
        thePlayer.canMove = false;
        thePlayer.isGrounded = true;
        theCamera.followTarget = false;
        theLevelManager.invincible = true;
        theLevelManager.levelMusic.Stop();
        theLevelManager.gameOverMusic.Play();

        thePlayer.playerRigidBody.velocity = Vector3.zero;

        PlayerPrefs.SetInt("CoinCount", theLevelManager.bloodCount);
        PlayerPrefs.SetInt("CurrentLives", theLevelManager.currentLives);

        PlayerPrefs.SetInt(levelToUnlock, 1);

        yield return new WaitForSeconds(waitToMove);

        movePlayer = true;

        yield return new WaitForSeconds(waitToLoad);

        SceneManager.LoadScene(levelToLoad);
    }
}
