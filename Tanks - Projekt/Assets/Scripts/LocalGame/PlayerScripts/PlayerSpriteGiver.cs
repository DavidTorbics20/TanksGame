using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//PlayerSpriteGiver makes the game more colorfull
public class PlayerSpriteGiver : MonoBehaviour
{
    public SpriteRenderer playerOneSprite;
    public SpriteRenderer playerTwoSprite;
    public Sprite[] sprites;

    //at the start of the game it hands out 1 of 8 random sprites to the players
    void Start()
    {
        playerOneSprite.sprite = sprites[PlayerPrefs.GetInt("playerOneSprite")];
        playerTwoSprite.sprite = sprites[PlayerPrefs.GetInt("playerTwoSprite")];
    }
}
