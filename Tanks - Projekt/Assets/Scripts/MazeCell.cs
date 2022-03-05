using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeCell : MonoBehaviour
{
    public GameObject top, right, bottom, left;
    public SpriteRenderer sprite;
    public bool visited;
    public int x, y;

    void Start()
    {
        visited = false;
    }
}
