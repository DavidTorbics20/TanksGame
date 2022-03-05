using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    public MazeCell cellPrefab;
    private MazeCell[,] cells;
    private Stack<string> carvedCells = new Stack<string>();
    public SpriteRenderer cellSprite;

    public int sizeX, sizeY;
    public float generationStepDelay;

    void Start()
    {
        //idea:
        //make two adjascent cells share one wall
        //for example: the right wall of currentCell is the left wall of nextCell
    }

    public void GeneratePath()
    {
        WaitForSeconds delay = new WaitForSeconds(generationStepDelay);

        //picks a cell to start at
        int rndX = Random.Range(1, sizeX);
        int rndY = Random.Range(1, sizeY);

        //mark fist cell and make it currentCell
        MazeCell nextCell;
        MazeCell currentCell = cells[rndX, rndY];
        currentCell.x = rndX;
        currentCell.y = rndY;
        currentCell.visited = true;

        //search for available neighbours in a loop and carve the path
        do
        {
            //push currentCell onto the Stack
            carvedCells.Push(currentCell.name);
            nextCell = EnumerateNeighbours(currentCell);
            if (nextCell == null)
            {
                break;
            }
            nextCell.visited = true;
            nextCell.sprite.color = new Color(255, 0, 0);
            BreakWalls(currentCell, nextCell);
            Debug.Log((currentCell.x, currentCell.y));
            currentCell = nextCell;
            //yield return delay;
        } while (carvedCells.Count != 0);
    }

    private MazeCell EnumerateNeighbours(MazeCell currentCell)
    {
        //return all possible neighbours of currentCell
        List<MazeCell> neighbours = new List<MazeCell> { };
        MazeCell neighbour;
        MazeCell nextCell;

        //top
        if (CheckIfPossible(currentCell.x, currentCell.y + 1)) 
        {
            MazeCell top = cells[currentCell.x, currentCell.y + 1];
            if (!top.visited)
            {
                top.x = currentCell.x;
                top.y = currentCell.y + 1;
                neighbour = cells[top.x, top.y];
                neighbours.Add(neighbour);
            }
        }
        //right
        if (CheckIfPossible(currentCell.x + 1, currentCell.y))
        {
            MazeCell right = cells[currentCell.x + 1, currentCell.y];
            if (!right.visited)
            {
                right.x = currentCell.x + 1;
                right.y = currentCell.y;
                neighbour = cells[right.x, right.y];
                neighbours.Add(neighbour);
            }
        }
        //bottom
        if (CheckIfPossible(currentCell.x, currentCell.y - 1))
        {
            MazeCell bottom = cells[currentCell.x, currentCell.y - 1];
            if (!bottom.visited)
            {
                bottom.x = currentCell.x;
                bottom.y = currentCell.y - 1;
                neighbour = cells[bottom.x, bottom.y];
                neighbours.Add(neighbour);
            }
        }
        //left
        if (CheckIfPossible(currentCell.x - 1, currentCell.y))
        {
            MazeCell left = cells[currentCell.x - 1, currentCell.y];
            if (!left.visited)
            {
                left.x = currentCell.x - 1;
                left.y = currentCell.y;
                neighbour = cells[left.x, left.y];
                neighbours.Add(neighbour);
            }
        }

        //if no neighbours available pop from stack
        if (neighbours.Count == 0)
        {
            carvedCells.Pop();
        }
        else
        {
            nextCell = PickARandomCell(neighbours);
            return nextCell;
        }

        return null;
    }

    private bool CheckIfPossible(int x, int y)
    {
        if (x < 0 || y < 0 || x > sizeX - 1 || y > sizeY - 1){
            return false;
        }else{
            return true;
        }
    }

    private MazeCell PickARandomCell(List<MazeCell> neighbours)
    {
        //get the possible neighbours from EnumerateNeighbours() and pick one
        MazeCell nextCell;
        int rnd = Random.Range(0, neighbours.Count);
        nextCell = neighbours[rnd];
        Debug.Log((nextCell.x, nextCell.y));
        return nextCell;
    }

    private void BreakWalls(MazeCell currentCell, MazeCell nextCell)
    {
        if (currentCell.x < nextCell.x)
        {
            currentCell.right.SetActive(false);
            nextCell.left.SetActive(false);
        }
        if (currentCell.x > nextCell.x)
        {
            currentCell.left.SetActive(false);
            nextCell.right.SetActive(false);
        }
        if (currentCell.y < nextCell.y)
        {
            currentCell.top.SetActive(false);
            nextCell.bottom.SetActive(false);
        }
        if (currentCell.y > nextCell.y)
        {
            currentCell.bottom.SetActive(false);
            nextCell.top.SetActive(false);
        }
    }

    public IEnumerator GenerateGrid()
    {
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
        newCell.name = "" + x + "," + y;
        newCell.transform.parent = transform;
        newCell.transform.localPosition = new Vector3(x + 0.5f, y + 0.5f, 0f);
    }
}
