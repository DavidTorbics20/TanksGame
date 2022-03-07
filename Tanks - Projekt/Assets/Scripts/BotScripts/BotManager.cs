using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotManager : MonoBehaviour
{
    public GameObject bot;
    private GameObject botInstance;

    public int maxBotsAlive;
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
        WaitForSeconds delay = new WaitForSeconds(2);

        while (count <= maxBotsAlive)
        {
            botInstance = Instantiate(bot) as GameObject;
            count += 1;
            yield return delay;
        }
    }
}
