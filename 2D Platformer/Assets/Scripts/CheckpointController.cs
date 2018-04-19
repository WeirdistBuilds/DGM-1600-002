using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour {

    public Sprite computerOff;
    public Sprite computerOn;
    public bool checkpointActive;
    private SpriteRenderer theSpriteRenderer;
    
    // Use this for initialization
	void Start () {
        theSpriteRenderer = GetComponent<SpriteRenderer>();
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            theSpriteRenderer.sprite = computerOn;
            checkpointActive = true;
        }
    }
}
