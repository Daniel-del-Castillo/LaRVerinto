using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction : int
{
    Up = 0,
    Right = 90,
    Down = 180,
    Left = 270,
}

public class TileBehaviour : MonoBehaviour
{
    public int index;
    private int[] directionValues = {0, 90, 180, 270};

    public void wakeUp(GameObject wall, GameObject ground, GameObject[] ivy, float ivyProbability)
    {
        if (gameObject.tag == "Border" || gameObject.tag == "Wall")
        {
            Instantiate(wall, gameObject.transform);
            if (Random.value <= ivyProbability)
            {
                spawnIvy(ivy);
            }
        }
        else if (gameObject.tag == "Path")
        {
            Instantiate(ground, gameObject.transform);
        }
    }

    private void spawnIvy(GameObject[] ivy)
    {
        foreach(Direction directionValue in directionValues) {  
            if (MazeController.instance.getGridTag(index, directionValue) == "Path") {
                int rnd = Random.Range(0, ivy.Length);
                Instantiate(ivy[rnd], transform.position, Quaternion.Euler(0f, ivy[rnd].transform.eulerAngles.y + (int)(directionValue), 0f), transform); // Con la entrada abajo
            }
        }
    }
}
