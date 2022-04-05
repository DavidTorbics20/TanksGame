using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject playerOne;
    public GameObject playerTwo;

    public static bool shouldSpawn;

    void Start()
    {
        SpawnPlayers();
    }

    public void SpawnPlayers()
    {
        playerOne.transform.localPosition = new Vector3(RandomNumber() + 0.5f, RandomNumber() + 0.5f, 0f);
        playerOne.transform.localRotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
        
        playerTwo.transform.localPosition = new Vector3(RandomNumber() + 0.5f, RandomNumber() + 0.5f, 0f);
        playerTwo.transform.localRotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
    }

    private int RandomNumber()
    {
        return Random.Range(0, 10);
    }
}
