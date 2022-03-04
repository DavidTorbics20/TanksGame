using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    public MazeCell cellPrefab;
    private MazeCell[,] cells;
    private MazeCell currentCell;

    public SpriteRenderer cellSprite;

    private Stack<string> carvedCells = new Stack<string>();
    public int sizeX, sizeY;
    public float generationStepDelay;

    void Start()
    {

    }

    public void GeneratePath()
    {
        //picks a cell to start at

        int rndX = Random.Range(1, sizeX);
        int rndY = Random.Range(1, sizeY);

        currentCell = cells[0, 0];
        currentCell.bottom.SetActive(false);
        currentCell.visited = true;
        carvedCells.Push(currentCell.name);

        foreach (var item in carvedCells)
        {

        }

        //mark fist cell and make it currentCell
        //push currentCell onto the Stack
        //search for available neighbours
    }

    private void EnumerateNeighbours()
    {
        //return all possible neighbours of currentCell
        //if no neighbours available pop from 
    }

    private void PickARandomCell()
    {
        //get the possible neighbours form EnumerateNeighbours() and pick on
        //after that make that cell to currentCell
    }

    public IEnumerator GenerateGrid()
    {
        int nr = 0;

        WaitForSeconds delay = new WaitForSeconds(generationStepDelay);
        cells = new MazeCell[sizeX, sizeY];
        for (int i = 0; i < sizeX; i++)
        {
            for (int j = 0; j < sizeY; j++)
            {
                yield return delay;
                CreateCell(j, i);
            }
        }
        GeneratePath();
    }

    private void CreateCell(int x, int y)
    {
        MazeCell newCell = Instantiate(cellPrefab) as MazeCell;
        cells[x, y] = newCell;
        newCell.name = "" + x +y;
        newCell.transform.parent = transform;
        newCell.transform.localPosition = new Vector3(x + 0.5f, y + 0.5f, 0f);
    }
}
