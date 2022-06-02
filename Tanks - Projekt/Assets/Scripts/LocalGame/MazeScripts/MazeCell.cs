using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//MazeCell sets and holds some values/data for each cell in the maze
public class MazeCell : MonoBehaviour
{
    public GameObject top, right, bottom, left;
    public SpriteRenderer sprite;
    public bool visited;
    public bool breakable;
    public int x, y;

    //the default value "visited" of the cell is to false
    void Start()
    {
        visited = false; 
    }
}
