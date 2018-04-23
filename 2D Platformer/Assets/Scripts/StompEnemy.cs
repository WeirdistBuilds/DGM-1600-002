using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StompEnemy : MonoBehaviour {

    private Rigidbody2D playerRigidBody;
    private LevelManager theLevelManager;

    public int bloodBonus;
    public int bonusAtBloodCount;
    public int livesAtBonus;

    public float bounceForce;
    public GameObject deathAnim;

	// Use this for initialization
	void Start () {
        playerRigidBody = transform.parent.GetComponent<Rigidbody2D>();
        theLevelManager = FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            other.gameObject.SetActive(false);
            //Destroy(other.gameObject);

            Instantiate(deathAnim, other.transform.position, other.transform.rotation);
            theLevelManager.AddBlood(bloodBonus);
            if (theLevelManager.bloodCount >= bonusAtBloodCount)
            {
                theLevelManager.AddBlood(-bonusAtBloodCount);
                theLevelManager.AddLives(livesAtBonus);

            }

            playerRigidBody.velocity = new Vector3(playerRigidBody.velocity.x, bounceForce, 0f);
        }

        if(other.tag == "Boss")
        {
            playerRigidBody.velocity = new Vector3(playerRigidBody.velocity.x, bounceForce, 0f);
            other.transform.parent.GetComponent<Boss>().takeDamage = true;
        }
    }
}
