using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//does the same thing as MazeGenerator but is for the online game
//OnlineMazeGenerator creates cells, breaks walls and makes cool patterns
//the resulting maze is then used for a quick round of Tanks
public class OnlineMazeGenerator : MonoBehaviour
{
    public MazeCell cellPrefab;
    private MazeCell[,] cells;
    private Stack<string> carvedCells = new Stack<string>();
    public SpriteRenderer cellSprite;

    public int sizeX, sizeY;
    public float generationStepDelay;
    public float chance;

    //Start a quick generation fo the maze
    void Start()
    {
        StartCoroutine(GenerateGrid());
        //Invoke("GenerateGrid", 0.0f);
    }

    //starts at a random coordinate
    //then goes through every cell in cells[] until every cells is marked as visited
    //with the use of Recursive Backtracking
    public IEnumerator GeneratePath() //alternativally i could use IEnumerator
    {
        //with yield return delay the player sees the step by step generation of the map
        WaitForSeconds delay = new WaitForSeconds(generationStepDelay);
        //

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


            //
            nextCell.sprite.color = new Color(255, 0, 0);
            //
            
            
            currentCell = nextCell;
            //with yield return delay the player sees the step by step generation of the map
            yield return delay;
        } while (carvedCells.Count != 0);



        //
        ClearColors();
        //    
    
    
    }

    //checks for cells if they are possible to visit and/or are not visited already
    //if one suitable is found picks that and adds it to neighbours
    private MazeCell EnumerateNeighbours(MazeCell currentCell)
    {
        //return all possible neighbours of currentCell
        List<MazeCell> neighbours = new List<MazeCell> { };
        MazeCell neighbour;
        MazeCell nextCell;

        //colors visited cells yellow for visual reasons
        //could/should remove this

        //
        currentCell.sprite.color = new Color(145, 25, 0);
        //
        
        
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

    //checks if the net cell choice is possible
    private bool CheckIfPossible(int x, int y)
    {
        if (x < 0 || y < 0 || x > sizeX - 1 || y > sizeY - 1)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    //get the possible neighbours from EnumerateNeighbours() and pick one
    private MazeCell PickARandomCell(List<MazeCell> neighbours)
    {
        //get the possible neighbours from EnumerateNeighbours() and pick one
        MazeCell nextCell;
        int rnd = Random.Range(0, neighbours.Count);
        return nextCell = neighbours[rnd];
    }

    //to make loops in the maze and not mess up the backtracking random walls have to be broken
    //also keeps the walls at the edges
    private void BreakWalls(MazeCell currentCell, MazeCell nextCell)
    {
        //depending on the direction where the maze will breaks walls will be set to false
        if (currentCell.x < nextCell.x){
            currentCell.right.SetActive(false);
        }if (currentCell.x > nextCell.x){
            nextCell.right.SetActive(false);
        }if (currentCell.y < nextCell.y){
            currentCell.top.SetActive(false);
        }if (currentCell.y > nextCell.y){
            nextCell.top.SetActive(false);
        }

        //sees if a wall is breakable 
        //if yes breaks a random one 
        //if no then no
        float rnd = Random.Range(0, (sizeX + sizeY) / 2);
        if (rnd <= chance && EdgeCases(currentCell.x, currentCell.y, nextCell.x, nextCell.y))
        {
            int rnd2 = Random.Range(0, 4);
            switch (rnd)
            {
                case 0:
                    currentCell.right.SetActive(false);
                    break;
                case 1:
                    nextCell.right.SetActive(false);
                    break;
                case 2:
                    currentCell.top.SetActive(false);
                    break;
                case 3:
                    nextCell.top.SetActive(false);
                    break;
                default:
                    break;
            }
        }
    }


    // !!! I added a "breakable" bool to MazeCell.cs
    // !!! in the future I could use that to mark the celle as breakable or not
    // !!! with that I could reduce the ammount of code by a lot


    //doesn't destroy walls if the wall is on either side of the grid
    private bool EdgeCases(int x, int y, int z, int a)
    {
        if (x == 0 || y == 0 || x == sizeX - 1 || y == sizeY - 1 || z == 0 || a == 0 || z == sizeX - 1 || a == sizeY - 1)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    //sets the cell color to white
    private void ClearColors()
    {
        foreach (var item in cells)
        {
            item.sprite.color = new Color(1f, 1f, 1f);
        }
    }

    //creates a XxY grid of cells with walls
    public IEnumerator GenerateGrid()
    {

        WaitForSeconds delay = new WaitForSeconds(generationStepDelay);
        cells = new MazeCell[sizeX, sizeY];
        for (int i = 0; i < sizeX; i++)
        {
            for (int j = 0; j < sizeY; j++)
            {
                CreateCell(j, i);
                yield return delay;
            }
        }
        StartCoroutine(GeneratePath());
    }

    //creates a cell 
    //depending on the x and y value it sets or removes some walls at generation
    private void CreateCell(int x, int y)
    {
        MazeCell newCell = Instantiate(cellPrefab) as MazeCell;
        cells[x, y] = newCell;
        if (x != 0 && y != 0)
        {
            newCell.left.SetActive(false);
            newCell.bottom.SetActive(false);
        }
        else if (x != 0 && y == 0)
        {
            newCell.left.SetActive(false);
        }
        else if (x == 0 && y != 0)
        {
            newCell.bottom.SetActive(false);
        }
        newCell.name = "" + x + "," + y;
        newCell.transform.parent = transform;
        newCell.transform.localPosition = new Vector3(x + 0.5f, y + 0.5f, 0f);
    }
}
