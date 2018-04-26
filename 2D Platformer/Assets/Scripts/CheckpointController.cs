using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour {

    public Sprite computerOff;
    public Sprite computerOn;
    public bool checkpointActive;
    private SpriteRenderer theSpriteRenderer;
    private LevelManager theLevelManager;
    
    // Use this for initialization
	void Start () {
        theSpriteRenderer = GetComponent<SpriteRenderer>();
        theLevelManager = FindObjectOfType<LevelManager>();
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" && !checkpointActive)
        {
            theSpriteRenderer.sprite = computerOn;
            theLevelManager.checkpointSound.Play();
            checkpointActive = true;
        }
    }
}
