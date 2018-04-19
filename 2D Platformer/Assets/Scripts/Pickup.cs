using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

    private LevelManager theLevelManager;
    public SpriteRenderer theSprite;

    public enum States { life, blood1, blood5, heart };
    public States pickupState;

    public Sprite blood1Sprite;
    public Sprite blood5Sprite;
    public int bonusAtBloodCount;
    public int blood1Value;
    public int blood5Value;
    public int livesAtBonus;

    public Sprite heartSprite;
    public int healthToAdd;

    public Sprite lifeSprite;
    public int livesToAdd;

    // Use this for initialization
    void Start() {
        theLevelManager = FindObjectOfType<LevelManager>();
        theSprite = GetComponent<SpriteRenderer>();

        switch (pickupState)
        {
            case States.life:
                theSprite.sprite = lifeSprite;
                break;
            case States.blood1:
                theSprite.sprite = blood1Sprite;
                break;
            case States.blood5:
                theSprite.sprite = blood5Sprite;
                break;
            case States.heart:
                theSprite.sprite = heartSprite;
                break;
            default:
                Debug.Log("didn't implement");
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            switch (pickupState)
            {
                case States.life:
                    theLevelManager.AddLives(livesToAdd);
                    break;
                case States.blood1:
                    theLevelManager.AddBlood(blood1Value);
                    if (theLevelManager.bloodCount >= bonusAtBloodCount)
                    {
                        theLevelManager.AddBlood(-bonusAtBloodCount);
                        theLevelManager.AddLives(livesAtBonus);

                    }
                    break;
                case States.blood5:
                    theLevelManager.AddBlood(blood5Value);
                    if (theLevelManager.bloodCount >= bonusAtBloodCount)
                    {
                        theLevelManager.AddBlood(-bonusAtBloodCount);
                        theLevelManager.AddLives(livesAtBonus);

                    }
                    break;
                case States.heart:
                    theLevelManager.GiveHealth(healthToAdd);
                    break;
                default:
                    Debug.Log("didn't implement");
                    break;
            }

            gameObject.SetActive(false);
        }
        
    }
}
