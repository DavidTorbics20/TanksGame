using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeManager : MonoBehaviour
{
    public SceneTransition sceneTransition;
    public MazeGenerator mazePrefab;
    private MazeGenerator mazeInstance;

    public static bool nextRound;

    void Start()
    {
        Begin();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) || nextRound)
        {
            StartCoroutine(Restart());
        }
        nextRound = false;
    }

    private void Begin()
    {
        mazeInstance = Instantiate(mazePrefab) as MazeGenerator;
        //StartCoroutine(mazeInstance.GenerateGrid());
    }

    IEnumerator Restart()
    {
        yield return new WaitForSeconds(1.5f);
        sceneTransition.LoadScene("LocalGame");
    }
}
