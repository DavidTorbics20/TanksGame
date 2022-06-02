using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//BotManager makes the bots move around the screen
public class BotMovement : MonoBehaviour
{
    public GameObject bot;

    public float botSpeed;
    public float rotation;
    private bool turnSide;

    //runs SpawnLocation at start
    void Start()
    {
        SpawnLocation();
    }

    //casts a rays infront of itself 
    //this ray detects other gameobjects
    //if a gameobject is hit the bot turns around
    void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y + 1), transform.up);

        bot.transform.position += transform.up * Time.deltaTime * botSpeed;

        Invoke("TurnRandom", 2.0f);

        if (hit.collider.tag == "Bot")
        {
            bot.transform.Rotate(new Vector3(0f, 0f, rotation) * Time.deltaTime);
        //    int rnd = Random.Range(0, 2);
        //    if (rnd == 0 && !turnSide)
        //    {
        //        bot.transform.Rotate(0f, 0f, rotation, Space.World);
        //        turnSide = true;
        //    }
        //    else if (rnd != 0 && turnSide)
        //    {
        //        bot.transform.Rotate(0f, 0f, -rotation, Space.World);
        //        turnSide = false;
        //    }
        }
    }

    //randomly spawns a bot in a certain area
    //this areas size is 20x16
    private void SpawnLocation()
    {
        int x = Random.Range(-7, 7);
        int y = Random.Range(-7, 7);
        
        int rnd = Random.Range(0, 4);
        switch (rnd)
        {
            case 0:
                bot.transform.position = new Vector2(x, 8);
                break;
            case 1:
                bot.transform.position = new Vector2(x, -8);
                break;
            case 2:
                bot.transform.position = new Vector2(10, y);
                break;
            case 3:
                bot.transform.position = new Vector2(-10, y);
                break;
            default:
                break;
        }

        bot.transform.Rotate(new Vector3(0f, 0f, Random.Range(0, 359)));
    }

    //turns around the bot when Raycast returns (hit == true)
    // ! currently only turns to one side
    // ! have to make it choose a side and keep it for a certain ammount
    public void TurnRandom()
    {
        int rnd = Random.Range(0, 3);
        int rndTurnSize = Random.Range(0, 10);
        switch (rnd)
        {
            case 0:
                
                break;
            case 1:
                bot.transform.Rotate(new Vector3(0f, 0f, -rndTurnSize) * Time.deltaTime);
                break;
            default:
                break;
        }            
    }

    //if the bot collides with an invisible walls around the spawn area then the 
    //gameobject gets destroyed
    //also allows a new bot to spawn afterwards
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "DeathZone")
        {
            Destroy(bot);
            BotManager.count -= 1;
        }
    }
}
