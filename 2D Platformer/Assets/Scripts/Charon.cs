using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Charon : MonoBehaviour {

    public GameObject boat;
    public GameObject credits;
    private Vector3 boatTarget;
    public Transform boatDestination;
    private Vector3 creditsTarget;
    public Transform creditsDestination;
    private Animator charonAnim;
    private PlayerController thePlayer;
    private CameraController theCamera;
    private LevelManager theLevelManager;

    public float moveSpeed;
    public float waitToMove;
    public float waitToLoad;
    private bool moveBoat;
    public bool hasCoin;


    // Use this for initialization
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerController>();
        theCamera = FindObjectOfType<CameraController>();
        theLevelManager = FindObjectOfType<LevelManager>();
        charonAnim = GetComponent<Animator>();
        boatTarget = boatDestination.position;
        creditsTarget = creditsDestination.position;
        if (PlayerPrefs.GetInt("EndCoin") > 0)
        {
            hasCoin = true;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (moveBoat)
        {
            boat.transform.position = Vector3.MoveTowards(boat.transform.position, boatTarget, moveSpeed * Time.deltaTime);
            credits.transform.position = Vector3.MoveTowards(credits.transform.position, creditsTarget, moveSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" && hasCoin)
        {
            Debug.Log("Running GameEndCo");
            StartCoroutine("GameEndCo");
        }
    } 

    public IEnumerator GameEndCo()
    {
        thePlayer.canMove = false;
        thePlayer.playerAnim.SetBool("Grounded", true);
        theCamera.followTarget = false;
        theLevelManager.invincible = true;
        theLevelManager.levelMusic.Stop();
        theLevelManager.endingMusic.Play();
        thePlayer.playerRigidBody.velocity = Vector3.zero;

        yield return new WaitForSeconds(waitToMove);

        charonAnim.SetBool("OnBoat", true);
        moveBoat = true;

        yield return new WaitForSeconds(waitToLoad);

        PlayerPrefs.SetInt("BloodCount", theLevelManager.bloodCount);
        PlayerPrefs.SetInt("CurrentLives", theLevelManager.currentLives);
        PlayerPrefs.SetInt("EndCoin", 0);
        SceneManager.LoadScene("MainMenu");
    }
}
