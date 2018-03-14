using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D playerRigidBody;

    public bool isGrounded;
    public float moveSpeed;
    public float jumpSpeed;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;

    private Animator playerAnim;

	// Use this for initialization
	void Start () {
        playerRigidBody = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "KillBox")
        {
            // placeholder
            gameObject.SetActive(false);
        }
    }

}
