using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//allows the maze to be replayed multiple times
public class MazeManager : MonoBehaviour
{
    public SceneTransition sceneTransition;
    public MazeGenerator mazePrefab;
    private MazeGenerator mazeInstance;

    public static bool nextRound;

    //Starts building the maze
    void Start()
    {
        Begin();
    }

    //if R is pressed the game restarts
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) || nextRound)
        {
            StartCoroutine(Restart());
        }
        nextRound = false;
    }

    //creates an instance of the maze gameobject
    //it automatically starts building the maze grid
    private void Begin()
    {
        mazeInstance = Instantiate(mazePrefab) as MazeGenerator;
        //StartCoroutine(mazeInstance.GenerateGrid());
    }

    //if the game is over the after 1.5 seconds the game restarts
    //the game scene is simply reloaded
    IEnumerator Restart()
    {
        yield return new WaitForSeconds(1.5f);
        sceneTransition.LoadScene("LocalGame");
    }
}
