using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D playerRigidBody;

    //jump variables
    public bool isGrounded;
    public float moveSpeed;
    private float activeMoveSpeed;
    public float jumpSpeed;

    //spawn variable
    public Vector3 spawnPoint;

    //ground variables
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool onPlatform;
    public float onPlatformSpeedMod;

    //stomp variable
    public GameObject stompBox;

    //animation variable
    private Animator playerAnim;

    //level manager
    public LevelManager theLevelManager;

    //knockback variables
    public float knockbackForce;
    public float knockbackLength;
    private float knockbackCounter;

    //invincibility variables
    public float iFrameLength;
    public float iFrameCounter;

    //SFX variables
    public AudioSource jumpSound;
    public AudioSource hurtSound;

    // Use this for initialization
    void Start () {
        playerRigidBody = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();

        theLevelManager = FindObjectOfType<LevelManager>();

        spawnPoint = transform.position;
        activeMoveSpeed = moveSpeed;
	}

    // Update is called once per frame
    void Update() {

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (knockbackCounter <= 0)
        {
            if (onPlatform)
            {
                activeMoveSpeed = moveSpeed * onPlatformSpeedMod;
            }
            else
            {
                activeMoveSpeed = moveSpeed;
            }

            if (Input.GetAxisRaw("Horizontal") > 0f)
            {
                playerRigidBody.velocity = new Vector3(activeMoveSpeed, playerRigidBody.velocity.y);
                transform.localScale = new Vector3(1f, 1f, 1f);
            }
            else if (Input.GetAxisRaw("Horizontal") < 0f)
            {
                playerRigidBody.velocity = new Vector3(-activeMoveSpeed, playerRigidBody.velocity.y);
                transform.localScale = new Vector3(-1f, 1f, 1f);
            }

            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                playerRigidBody.velocity = new Vector3(playerRigidBody.velocity.x, jumpSpeed);
                jumpSound.Play();
            }

            playerAnim.SetFloat("Speed", Mathf.Abs(playerRigidBody.velocity.x));
            playerAnim.SetBool("Grounded", isGrounded);

            if (playerRigidBody.velocity.y < 0)
            {
                stompBox.SetActive(true);
            }
            else
            {
                stompBox.SetActive(false);
            }
        }

        if (knockbackCounter > 0)
        {
            knockbackCounter -= Time.deltaTime;

            if(transform.localScale.x > 0)
            {
                playerRigidBody.velocity = new Vector3(-knockbackForce, knockbackForce, 0f);
            }
            else
            {
                playerRigidBody.velocity = new Vector3(knockbackForce, knockbackForce, 0f);
            }
            
        }
        if (iFrameCounter > 0)
        {
            iFrameCounter -= Time.deltaTime;
        }
        else
        {
            theLevelManager.invincible = false;
        }
	}

    public void Knockback()
    {
        knockbackCounter = knockbackLength;
        iFrameCounter = iFrameLength;
        theLevelManager.invincible = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "KillBox")
        {
            theLevelManager.HurtPlayer(theLevelManager.maxHealth);
            //theLevelManager.Respawn();
        }

        if(other.tag == "Checkpoint")
        {
            spawnPoint = other.transform.position;
        }

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "MovingPlatform")
        {
            transform.parent = other.transform;
            onPlatform = true;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "MovingPlatform")
        {
            transform.parent = null;
            onPlatform = false;
        }
    }
}
