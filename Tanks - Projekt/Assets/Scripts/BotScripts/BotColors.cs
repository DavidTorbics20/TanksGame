using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//when a bot spawns its sprites get some random colors
public class BotColors : MonoBehaviour
{
    public SpriteRenderer[] botSprite;

    //a random normalized number is chosen and varied to make the bot a little more colorfull
    void Start()
    {
        float r = Random.Range(0f, 1f);
        float g = Random.Range(0f, 1f);
        float b = Random.Range(0f, 1f);

        botSprite[0].color = new Color(r - 0.1f, g - 0.1f, b - 0.1f);
        botSprite[1].color = new Color(r + 0.06f, g + 0.06f, b + 0.06f);
        botSprite[2].color = new Color(r + 0.06f, g + 0.06f, b + 0.06f);
        botSprite[3].color = new Color(r, g, b);
        botSprite[4].color = new Color(r - 0.1f, g - 0.1f, b - 0.1f);
        botSprite[5].color = new Color(r, g, b);
    }
}