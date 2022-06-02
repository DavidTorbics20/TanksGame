using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//manages the ingame bots
public class BotManager : MonoBehaviour
{
    public GameObject bot;
    private GameObject botInstance;

    public int maxBotsAlive;
    [Range (0, 5)]
    public float delayTime;
    public static int count;

    //at start runs StartSpawn()
    void Start()
    {
        StartSpawn();
    }

    //start a courutine that spawns bots every x seconds
    //x can be set inside the editor
    private void StartSpawn()
    {
        StartCoroutine(SpawnBot());
    }

    //clones a bot gameobject 
    //then waits x seconds and repeats
    public IEnumerator SpawnBot()
    {
        WaitForSeconds delay = new WaitForSeconds(delayTime);

        while (count <= maxBotsAlive)
        {
            botInstance = Instantiate(bot) as GameObject;
            count += 1;
            yield return delay;
        }
    }
}
