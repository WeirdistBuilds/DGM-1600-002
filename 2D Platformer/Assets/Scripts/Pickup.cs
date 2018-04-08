using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

    private LevelManager theLevelManager;
    public SpriteRenderer theSprite;

    public enum States { life, coin1, coin5, heart };
    public States pickupState;

    public Sprite coin1Sprite;
    public Sprite coin5Sprite;
    public int bonusAtCoinCount;
    public int coin1Value;
    public int coin5Value;
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
            case States.coin1:
                theSprite.sprite = coin1Sprite;
                break;
            case States.coin5:
                theSprite.sprite = coin5Sprite;
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
                case States.coin1:
                    theLevelManager.AddCoins(coin1Value);
                    if (theLevelManager.coinCount >= bonusAtCoinCount)
                    {
                        theLevelManager.AddCoins(-bonusAtCoinCount);
                        theLevelManager.AddLives(livesAtBonus);

                    }
                    break;
                case States.coin5:
                    theLevelManager.AddCoins(coin5Value);
                    if (theLevelManager.coinCount >= bonusAtCoinCount)
                    {
                        theLevelManager.AddCoins(-bonusAtCoinCount);
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
