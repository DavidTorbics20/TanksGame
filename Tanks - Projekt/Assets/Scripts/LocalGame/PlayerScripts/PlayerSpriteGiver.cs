using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpriteGiver : MonoBehaviour
{
    public SpriteRenderer playerOneSprite;
    public SpriteRenderer playerTwoSprite;
    public Sprite[] sprites;

    void Start()
    {
        playerOneSprite.sprite = sprites[PlayerPrefs.GetInt("playerOneSprite")];
        playerTwoSprite.sprite = sprites[PlayerPrefs.GetInt("playerTwoSprite")];
    }
}
