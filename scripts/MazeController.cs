using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeController : MonoBehaviour
{
    private MazeSpawner mazeSpawner;
    public static MazeController instance;

    [Header("Debugging")]

    public int width = 25;
    public int height = 25;
    private int separation = 10;
    [Range(1, 5)]
    [SerializeField] private int rad = 1;
    public float ivyProbability = 0.3f;

    [Header("Graphics")]

    public GameObject wall;
    public GameObject ground;
    public GameObject[] ivy = new GameObject[4];

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        mazeSpawner = gameObject.AddComponent<MazeSpawner>() as MazeSpawner;
    }

    private void Start()
    {
        mazeSpawner.width = width;
        mazeSpawner.height = height;
        mazeSpawner.separation = separation;

        spawnMaze();

        foreach (GameObject tile in mazeSpawner.grid)
        {
            tile.GetComponent<TileBehaviour>().wakeUp(wall, ground, ivy, ivyProbability);
        }
    }

    private void spawnMaze()
    {
        mazeSpawner.createGrid();
        mazeSpawner.tagBorder();
        mazeSpawner.generatePath();
        mazeSpawner.generateCenter(rad);
    }

    public string getGridTag(int index, Direction dir)
    {
        int check = 0;
        switch(dir)
        {
            case Direction.Up:
                check = index - width;
                if (check > 0)
                    return mazeSpawner.grid[check].tag;
                break;
            case Direction.Down:
                check = index + width;
                if (check < mazeSpawner.grid.Count)
                    return mazeSpawner.grid[check].tag;
                break;
            case Direction.Right:
                check = index + 1;
                if (check < mazeSpawner.grid.Count && (check + 1) % width != 0)
                    return mazeSpawner.grid[check].tag;
                break;
            case Direction.Left:
                check = index - 1;
                if (check > 0 && check % width != 0)
                    return mazeSpawner.grid[check].tag;
                break;
        }

        return null;
    }
}
