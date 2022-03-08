using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotManager : MonoBehaviour
{
    public GameObject bot;
    private GameObject botInstance;

    public int maxBotsAlive;
    [Range (0, 5)]
    public float delayTime;
    public static int count;

    void Start()
    {
        StartSpawn();
    }

    private void StartSpawn()
    {
        StartCoroutine(SpawnBot());
    }

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
