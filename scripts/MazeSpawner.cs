using System.Collections.Generic;
using UnityEngine;

public class MazeSpawner : MonoBehaviour
{
    public int width = 25;
    public int height = 25;
    public float separation = 10f;
    [HideInInspector]
    public List<GameObject> grid = new List<GameObject>();

    /* Maze generation steps:
     * 
     * 1) Create a grid of GameObjects, stored in grid[] -> createGrid()
     * 2) Tag the borders of the maze -> tagBorder()
     * 3) Genarete maze using tags -> generatePath()
     * 4) Generate a center to the maze -> generateCenter()
    */

    public void createGrid()
    {
        GameObject tile = new GameObject("Tile");
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                GameObject newCell = Instantiate(tile,
                    new Vector3(transform.position.x + separation * y, transform.position.y, transform.position.z + separation * x),
                    Quaternion.identity) as GameObject;
                TileBehaviour script = newCell.AddComponent<TileBehaviour>() as TileBehaviour;
                newCell.transform.parent = gameObject.transform;
                grid.Add(newCell);
                script.index = grid.Count - 1;
            }
        }
        Destroy(tile);
    }

    public void tagBorder()
    {
        // Tag borders as so
        for (int i = 0; i < width; i++)
        {
            grid[i].gameObject.tag = "Border";
            grid[(width * (height - 1)) + i].gameObject.tag = "Border";
        }

        for (int i = 1; i < height - 1; i++)
        {
            grid[width * i].gameObject.tag = "Border";
            grid[(width * (i + 1)) - 1].gameObject.tag = "Border";
        }

    }

    public void generatePath()
    {
        GameObject currentTile = null;
        List<GameObject> stack = new List<GameObject>();

        // Assign a start tile, mark as visited and push it into the stack
        do
        {
            currentTile = grid[width + 1];
        } while (currentTile.tag == "Border");

        currentTile.tag = "Path";
        stack.Add(currentTile);

        // Main genaration loop
        while (stack.Count != 0)
        {
            List<GameObject> availNeigh = new List<GameObject>();
            List<GameObject> availCorridor = new List<GameObject>();
            TileBehaviour tileBehav = currentTile.GetComponent<TileBehaviour>();

            // Check neighbours status
            checkNeighbour(tileBehav.index, availNeigh, availCorridor, 1); // Right
            checkNeighbour(tileBehav.index, availNeigh, availCorridor, -1); // Left
            checkNeighbour(tileBehav.index, availNeigh, availCorridor, width); // Down
            checkNeighbour(tileBehav.index, availNeigh, availCorridor, -width); // Up

            if (availNeigh.Count == 0)
            {
                if (stack.Count != 0)
                {
                    currentTile = stack[stack.Count - 1];
                    stack.RemoveAt(stack.Count - 1);
                }
                else
                    break; // Done!
            }
            else
            {
                int newTile = Random.Range(0, availNeigh.Count);
                availCorridor[newTile].tag = "Path";
                stack.Add(currentTile);

                currentTile = availNeigh[newTile];
                currentTile.tag = "Path";
            }
        }

        foreach (GameObject tile in grid)
        {
            if (tile.tag == "Untagged")
                tile.tag = "Wall";
        }
    }

    private void checkNeighbour(int currentTile, List<GameObject> availNeigh, List<GameObject> availCorridor, int pos)
    {
        if (currentTile + pos * 2 < 0 || currentTile + pos * 2 > width * height)
            return;

        if (grid[currentTile + pos].tag != "Border")
        {
            if (grid[currentTile + pos * 2].tag != "Border" && grid[currentTile + pos * 2].tag != "Path")
            {
                availCorridor.Add(grid[currentTile + pos]);
                availNeigh.Add(grid[currentTile + pos * 2]);
            }
        }
    }

    public void generateCenter(int rad)
    {
        int center = (height / 2) * width + width / 2;

        grid[center].tag = "Path";

        for (int i = 1; i <= rad; i++)
        {
            for (int j = -i; j <= i; j++)
            {
                grid[(center - width * i) + j].tag = "Path"; // Up
                grid[(center + width * i) + j].tag = "Path"; // Down
                grid[(center + i) + (width * j)].tag = "Path"; // Right
                grid[(center - i) + (width * j)].tag = "Path"; // Left	
            }
        }
    }

}