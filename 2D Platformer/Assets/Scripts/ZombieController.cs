using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour {

    public Transform leftPoint;
    public Transform rightPoint;

    public float moveSpeed;
    public bool movingRight;

    private Rigidbody2D zombieRigidBody;


	// Use this for initialization
	void Start () {
        zombieRigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
        if(movingRight && transform.position.x > rightPoint.position.x)
        {
            movingRight = false;
        }
        if(!movingRight && transform.position.x < leftPoint.position.x)
        {
            movingRight = true;
        }

        if(movingRight)
        {
            zombieRigidBody.velocity = new Vector3(moveSpeed, zombieRigidBody.velocity.y, 0f);
        }
        else
        {
            zombieRigidBody.velocity = new Vector3(-moveSpeed, zombieRigidBody.velocity.y, 0f);
        }

    }
}
