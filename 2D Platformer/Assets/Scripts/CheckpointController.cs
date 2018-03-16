using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour {

    public Sprite flagClosed;
    public Sprite flagOpen;
    public bool checkpointActive;
    private SpriteRenderer flagSpriteRenderer;
    
    // Use this for initialization
	void Start () {
        flagSpriteRenderer = GetComponent<SpriteRenderer>();
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            flagSpriteRenderer.sprite = flagOpen;
            checkpointActive = true;
        }
    }
}
