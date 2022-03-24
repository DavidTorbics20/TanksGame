using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Sprites;

public class PlayerSpriteChooser : MonoBehaviour
{
    Image image;

    public Image gameImage;
    public SpriteRenderer playerSprite;
    public Sprite[] sprites;
    private int playerSpriteCount = 0;

    void Start()
    {
        image = GetComponent<Image>();
        image.sprite = sprites[playerSpriteCount];
        gameImage.sprite = sprites[playerSpriteCount];
        playerSprite.sprite = sprites[playerSpriteCount];
    }

    public void ChooseLeft()
    {
        playerSpriteCount -= 1;
        if (playerSpriteCount <= 0)
        {
            image.sprite = sprites[sprites.Length - 1];
            gameImage.sprite = sprites[sprites.Length - 1];
            playerSprite.sprite = sprites[sprites.Length - 1];
            playerSpriteCount = sprites.Length - 1;
        }
        else if (playerSpriteCount >= sprites.Length)
        {
            image.sprite = sprites[0];
            gameImage.sprite = sprites[0];
            playerSprite.sprite = sprites[0];
            playerSpriteCount = 0;
        }
        else 
        {
            image.sprite = sprites[playerSpriteCount];
            gameImage.sprite = sprites[playerSpriteCount];
            playerSprite.sprite = sprites[playerSpriteCount];
        }
    }

    public void ChooseRight()
    {
        playerSpriteCount += 1;
        if (playerSpriteCount <= 0)
        {
            image.sprite = sprites[sprites.Length - 1];
            gameImage.sprite = sprites[sprites.Length - 1];
            playerSprite.sprite = sprites[sprites.Length - 1];
            playerSpriteCount = sprites.Length - 1;
        }
        else if (playerSpriteCount >= sprites.Length)
        {
            image.sprite = sprites[0];
            gameImage.sprite = sprites[0];
            playerSprite.sprite = sprites[0];
            playerSpriteCount = 0;
        }
        else
        {
            image.sprite = sprites[playerSpriteCount];
            gameImage.sprite = sprites[playerSpriteCount];
            playerSprite.sprite = sprites[playerSpriteCount];
        }
    }


}
