using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//spawns players at the beginning of each round
public class PlayerSpawner : MonoBehaviour
{
    public GameObject playerOne;
    public GameObject playerTwo;

    public static bool shouldSpawn;

    //spawns players
    void Start()
    {
        SpawnPlayers();
    }

    //sets the players x and y locations to a number from 0 to 9
    //these coordinates then are moved by 0.5 to fit right into
    //the middle of the cell
    public void SpawnPlayers()
    {
        playerOne.transform.localPosition = new Vector3(RN() + 0.5f, RN() + 0.5f, 0f);
        playerOne.transform.localRotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
        
        playerTwo.transform.localPosition = new Vector3(RN() + 0.5f, RN() + 0.5f, 0f);
        playerTwo.transform.localRotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
    }

    //RN stand for RandomNumber 
    //made it so I don't have to type it out Random.Range(0, 10) so often
    private int RN()
    {
        return Random.Range(0, 10);
    }
}
