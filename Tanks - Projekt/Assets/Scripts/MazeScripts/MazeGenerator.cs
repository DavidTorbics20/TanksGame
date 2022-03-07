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
        Invoke("GenerateGrid", 0.0f);
    }

    public void GeneratePath() //alternativally i could use IEnumerator
    {
        //WaitForSeconds delay = new WaitForSeconds(generationStepDelay);

        //picks a cell to start at
        int rndX = Random.Range(1, sizeX);
        int rndY = Random.Range(1, sizeY);
        Debug.Log(rndX + "," + rndY);

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

        currentCell.sprite.color = new Color(145, 25, 0);
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

        //if no neighbours found go back to the point where at least 1 neighbour exists
        if (neighbours.Count == 0 && carvedCells.Count >= 1)
        {
            string lastCellOnStack = carvedCells.Peek();
            string[] coordinates = lastCellOnStack.Split(',');
            currentCell = cells[System.Convert.ToInt32(coordinates[0]), System.Convert.ToInt32(coordinates[1])];
            carvedCells.Pop();
            return EnumerateNeighbours(currentCell);
        }
        else if (neighbours.Count != 0)
        {
            nextCell = PickARandomCell(neighbours);
            BreakWalls(currentCell, nextCell);
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
        return nextCell = neighbours[rnd];
    }

    private void BreakWalls(MazeCell currentCell, MazeCell nextCell)
    {
        if (currentCell.x < nextCell.x){
            currentCell.right.SetActive(false);
        }if (currentCell.x > nextCell.x){
            nextCell.right.SetActive(false); 
        }if (currentCell.y < nextCell.y){
            currentCell.top.SetActive(false);
        }if (currentCell.y > nextCell.y){
            nextCell.top.SetActive(false);
        }
    }

    public void GenerateGrid()
    {
        cells = new MazeCell[sizeX, sizeY];
        for (int i = 0; i < sizeX; i++)
        {
            for (int j = 0; j < sizeY; j++)
            {
                CreateCell(j, i);
            }
        }
        //StartCoroutine(GeneratePath());
        Invoke("GeneratePath", 0.1f);
    }

    private void CreateCell(int x, int y)
    {
        MazeCell newCell = Instantiate(cellPrefab) as MazeCell;
        cells[x, y] = newCell;
        if(x != 0 && y != 0){
            newCell.left.SetActive(false);
            newCell.bottom.SetActive(false);
        }else if (x != 0 && y == 0){
            newCell.left.SetActive(false);
        }else if (x == 0 && y != 0){
            newCell.bottom.SetActive(false);
        }
        newCell.name = "" + x + "," + y;
        newCell.transform.parent = transform;
        newCell.transform.localPosition = new Vector3(x + 0.5f, y + 0.5f, 0f);
    }
}
