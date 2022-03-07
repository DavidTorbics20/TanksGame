using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeManager : MonoBehaviour
{
    public MazeGenerator mazePrefab;
    private MazeGenerator mazeInstance;

    void Start()
    {
        Begin();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Restart();
        }
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
