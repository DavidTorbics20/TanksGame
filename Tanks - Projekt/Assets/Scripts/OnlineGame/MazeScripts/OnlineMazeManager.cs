using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlineMazeManager : MonoBehaviour
{
    public SceneTransition sceneTransition;
    public OnlineMazeGenerator mazePrefab;
    private OnlineMazeGenerator mazeInstance;

    public static bool nextRound;

    void Start()
    {
        Begin();
    }

    private void Begin()
    {
        mazeInstance = Instantiate(mazePrefab) as OnlineMazeGenerator;
        //StartCoroutine(mazeInstance.GenerateGrid());
    }

    IEnumerator RoundOver()
    {
        yield return new WaitForSeconds(1.5f);
        sceneTransition.LoadScene("OnlineGameLobby");
    }
}
