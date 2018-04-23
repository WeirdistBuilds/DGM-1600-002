using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobController : MonoBehaviour {

    public float moveSpeed;
    private bool canMove;

    private Rigidbody2D globRigidBody;

	// Use this for initialization
	void Start () {
        globRigidBody = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
		if(canMove)
        {
            globRigidBody.velocity = new Vector3(-moveSpeed, globRigidBody.velocity.y, 0f);
        }
	}

    private void OnBecameVisible()
    {
        canMove = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "KillBox")
        {
            gameObject.SetActive(false);
            //Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        canMove = false;
    }
}
