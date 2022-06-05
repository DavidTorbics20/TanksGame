using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//simulat to MazeManager just for online game only
//allows the maze to be replayed multiple times
public class OnlineMazeManager : MonoBehaviour
{
    public SceneTransition sceneTransition;
    public OnlineMazeGenerator mazePrefab;
    private OnlineMazeGenerator mazeInstance;

    public static bool nextRound;

    //Starts building the maze
    void Start()
    {
        Begin();
    }

    //creates an instance of the maze gameobject
    private void Begin()
    {
        mazeInstance = Instantiate(mazePrefab) as OnlineMazeGenerator;
        //StartCoroutine(mazeInstance.GenerateGrid());
    }

    //when the round is over an anomation is played 
    //still work in progress
    IEnumerator RoundOver()
    {
        //work in progress
        yield return new WaitForSeconds(1.5f);
        sceneTransition.LoadScene("OnlineGameLobby");
    }
}
