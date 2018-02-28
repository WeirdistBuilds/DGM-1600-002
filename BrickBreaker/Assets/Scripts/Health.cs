using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour {

    private SpriteRenderer spriteRenderer;
    public Sprite brickWhole;
    public Sprite brickCracked;
    public Sprite brickBroken;
    public int health;

    void Start ()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer.sprite == null)
            spriteRenderer.sprite = brickWhole;
        GameObject.FindObjectOfType<GameManager>().AddBrick();

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        health--;
                
        if (health <= 0)
        {
            Destroy(gameObject);
            GameObject.FindObjectOfType<GameManager>().MinusBrick();
            Debug.Log("Brick Count: " + GameObject.FindObjectOfType<GameManager>().GetBrickCount());
            if (GameObject.FindObjectOfType<GameManager>().GetBrickCount() <= 0)
            {
                GameObject.FindObjectOfType<GameManager>().LoadNextLevel();
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
