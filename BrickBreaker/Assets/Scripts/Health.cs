using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour {

    private SpriteRenderer spriteRenderer;
    private GameManager theGameManager;
    public Sprite brickWhole;
    public Sprite brickCracked;
    public Sprite brickBroken;
    public int health;

    void Start ()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        theGameManager = GameObject.FindObjectOfType<GameManager>();
        if (spriteRenderer.sprite == null)
            spriteRenderer.sprite = brickWhole;
        theGameManager.AddBrick();

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        health--;
                
        if (health <= 0)
        {
            Destroy(gameObject);
            theGameManager.MinusBrick();
            Debug.Log("Brick Count: " + theGameManager.GetBrickCount());
            if (theGameManager.GetBrickCount() <= 0)
            {
                theGameManager.IncreaseLevel();
                theGameManager.LoadNextLevel();
            }
        }
        ChangeSprite();
    }


    void ChangeSprite()
    {
        if (health == 3)
        {
            spriteRenderer.sprite = brickWhole;
        }
        else if (health == 2)
        {
            spriteRenderer.sprite = brickCracked;        
        }
        else if (health == 1)
        {
            spriteRenderer.sprite = brickBroken;
        }
        else
        {
            spriteRenderer.sprite = brickBroken;
        }
    }



}
