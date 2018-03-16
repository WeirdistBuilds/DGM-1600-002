using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D playerRigidBody;

    public bool isGrounded;
    public float moveSpeed;
    public float jumpSpeed;
    public Vector3 spawnPoint;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;

    private Animator playerAnim;

    public LevelManager theLevelManager;
    

	// Use this for initialization
	void Start () {
        playerRigidBody = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();

        theLevelManager = FindObjectOfType<LevelManager>();

        spawnPoint = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (Input.GetAxisRaw("Horizontal") > 0f)
        {
            playerRigidBody.velocity = new Vector3(moveSpeed, playerRigidBody.velocity.y);
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (Input.GetAxisRaw("Horizontal") < 0f)
        {
            playerRigidBody.velocity = new Vector3(-moveSpeed, playerRigidBody.velocity.y);
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            playerRigidBody.velocity = new Vector3(playerRigidBody.velocity.x, jumpSpeed);
        }

        playerAnim.SetFloat("Speed", Mathf.Abs(playerRigidBody.velocity.x));
        playerAnim.SetBool("Grounded", isGrounded);
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "KillBox")
        {
            theLevelManager.Respawn();
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
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "MovingPlatform")
        {
            transform.parent = null;
        }
    }

}
