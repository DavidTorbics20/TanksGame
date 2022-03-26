using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject playerOne;
    public GameObject playerTwo;

    public static bool shouldSpawn;

    void Update()
    {
        if (shouldSpawn)
        {
            SpawnPlayers();
            shouldSpawn = false;
        }
    }

    public void SpawnPlayers()
    {
        if (!playerOne.activeSelf)
        {
            PlayerTwoScore.scoreValue += 1;
            Debug.Log("P1 activate");
            playerOne.SetActive(true);
            //GameObject.Instantiate(playerOne, new Vector3(RandomNumber(), RandomNumber(), 0f), Quaternion.identity);
        }

        playerOne.transform.localPosition = new Vector3(RandomNumber() + 0.5f, RandomNumber() + 0.5f, 0f);
        playerOne.transform.localRotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
        
        if (!playerTwo.activeSelf)
        {
            PlayerOneScore.scoreValue += 1;
            Debug.Log("P2 activate");
            playerTwo.SetActive(true);
            //GameObject.Instantiate(playerTwo, new Vector3(RandomNumber(), RandomNumber(), 0f), Quaternion.identity);
        }

        playerTwo.transform.localPosition = new Vector3(RandomNumber() + 0.5f, RandomNumber() + 0.5f, 0f);
        playerTwo.transform.localRotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
    }

    private int RandomNumber()
    {
        return Random.Range(0, 10);
    }
}
