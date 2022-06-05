using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Sprites;

//lets the player choose a sprite to distinguish each other
public class PlayerSpriteChooser : MonoBehaviour
{
    Image image;

    public Sprite[] sprites;
    private int playerSpriteCount = 0;
    private int playerSpriteCount2 = 0;

    //gets the image element of the color choosing menu
    //starts counting the current sprite
    void Start()
    {
        image = GetComponent<Image>();
        image.sprite = sprites[playerSpriteCount];
        PlayerPrefs.SetInt("playerOneSprite", playerSpriteCount);
        PlayerPrefs.SetInt("playerTwoSprite", playerSpriteCount2);
    }

    //cycles the sprites counting down
    //after reaching an end it begins from the other side 
    public void ChooseLeft()
    {
        playerSpriteCount -= 1;
        if (playerSpriteCount < 0)
        {
            image.sprite = sprites[sprites.Length - 1];
            playerSpriteCount = sprites.Length - 1;
        }
        else if (playerSpriteCount >= sprites.Length)
        {
            image.sprite = sprites[0];
            playerSpriteCount = 0;
        }
        else 
        {
            image.sprite = sprites[playerSpriteCount];
        }
        PlayerPrefs.SetInt("playerOneSprite", playerSpriteCount);
    }

    //cycles the sprites counting up
    //after reaching an end it begins from the other side 
    public void ChooseRight()
    {
        playerSpriteCount += 1;
        if (playerSpriteCount <= 0)
        {
            image.sprite = sprites[sprites.Length - 1];
            playerSpriteCount = sprites.Length - 1;
        }
        else if (playerSpriteCount >= sprites.Length)
        {
            image.sprite = sprites[0];
            playerSpriteCount = 0;
        }
        else
        {
            image.sprite = sprites[playerSpriteCount];
        }
        PlayerPrefs.SetInt("playerOneSprite", playerSpriteCount);
    }

    //cycles the sprites counting down
    //after reaching an end it begins from the other side 
    public void ChooseLeft2()
    {
        playerSpriteCount2 -= 1;
        if (playerSpriteCount2 < 0)
        {
            image.sprite = sprites[sprites.Length - 1];
            playerSpriteCount2 = sprites.Length - 1;
        }
        else if (playerSpriteCount2 >= sprites.Length)
        {
            image.sprite = sprites[0];
            playerSpriteCount2 = 0;
        }
        else
        {
            image.sprite = sprites[playerSpriteCount2];
        }
        PlayerPrefs.SetInt("playerTwoSprite", playerSpriteCount2);
    }

    //cycles the sprites counting up
    //after reaching an end it begins from the other side 
    public void ChooseRight2()
    {
        playerSpriteCount2 += 1;
        if (playerSpriteCount2 <= 0)
        {
            image.sprite = sprites[sprites.Length - 1];
            playerSpriteCount2 = sprites.Length - 1;
        }
        else if (playerSpriteCount2 >= sprites.Length)
        {
            image.sprite = sprites[0];
            playerSpriteCount2 = 0;
        }
        else
        {
            image.sprite = sprites[playerSpriteCount2];
        }
        PlayerPrefs.SetInt("playerTwoSprite", playerSpriteCount2);
    }

    //the chosen sprite is saved for later use
    public void SaveSprites()
    {
        PlayerPrefs.SetInt("playerOneSprite", playerSpriteCount);
        PlayerPrefs.SetInt("playerTwoSprite", playerSpriteCount2);
        PlayerPrefs.Save();
    }
}
