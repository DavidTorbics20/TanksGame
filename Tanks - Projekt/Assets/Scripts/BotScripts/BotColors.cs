using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotColors : MonoBehaviour
{
    public SpriteRenderer[] botSprite;

    void Start()
    {
        //paint bot
        float r = Random.Range(0f, 1f);
        float g = Random.Range(0f, 1f);
        float b = Random.Range(0f, 1f);

        foreach (var item in botSprite)
        {

            item.color = new Color(r, g, b);
        }
        //botSprite[1].color = new Color(r, g, b);
        //botSprite[2].color = new Color(r, g, b);
        //botSprite[3].color = new Color(r, g, b);
        //botSprite[4].color = new Color(r, g, b);
        //botSprite[5].color = new Color(r, g, b);
    }
}
