using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderController : MonoBehaviour {

    public float moveSpeed;
    private bool canMove;

    private Rigidbody2D spiderRigidBody;

	// Use this for initialization
	void Start () {
        spiderRigidBody = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
		if(canMove)
        {
            spiderRigidBody.velocity = new Vector3(-moveSpeed, spiderRigidBody.velocity.y, 0f);
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
