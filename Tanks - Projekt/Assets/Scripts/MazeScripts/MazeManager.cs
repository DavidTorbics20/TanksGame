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
        if (Input.GetKeyDown(KeyCode.Space) || nextRound)
        {
            sceneTransition.LoadScene("LocalGame");
        }
        nextRound = false;
    }

    private void Begin()
    {
        mazeInstance = Instantiate(mazePrefab) as MazeGenerator;
        //StartCoroutine(mazeInstance.GenerateGrid());
    }

    private void Restart()
    {
        StopAllCoroutines();
        Destroy(mazeInstance.gameObject);
        Begin();
    }
}
