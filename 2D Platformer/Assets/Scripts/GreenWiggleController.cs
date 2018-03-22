using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenWiggleController : MonoBehaviour {

    public Transform leftPoint;
    public Transform rightPoint;

    public float moveSpeed;
    public bool movingRight;

    private Rigidbody2D greenWiggleRigidBody;


	// Use this for initialization
	void Start () {
        greenWiggleRigidBody = GetComponent<Rigidbody2D>();
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
            greenWiggleRigidBody.velocity = new Vector3(moveSpeed, greenWiggleRigidBody.velocity.y, 0f);
        }
        else
        {
            greenWiggleRigidBody.velocity = new Vector3(-moveSpeed, greenWiggleRigidBody.velocity.y, 0f);
        }

    }
}
