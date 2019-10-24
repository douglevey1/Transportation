using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject cubePrefab;
    public static GameObject activeCube;
    public Vector3 cubePos;
    public float xPos, yPos;
    public static GameObject[,] cubeGrid;
    public static int gridX, gridY;
    public static bool planeClicked = false;
    int setX = 0, setY = 0;

    public void Start()
    {
        //Grid size
        gridX = 16;
        gridY = 9;
        cubeGrid = new GameObject[gridX, gridY];
        //Physical cube positions
        xPos = -15;
        yPos = 9;
        //Spawns cubes and assigns them to each space in the cubeGrid array
        for (int x = 0; x < (gridX * gridY); x++)
        {
            cubePos = new Vector3(xPos, yPos, 0);
            cubeGrid[setX, setY] = Instantiate(cubePrefab, cubePos, Quaternion.identity);
            xPos += 2;
            setX++;
            //once cubes reach the end of the screen, the position is set back to the beginning
            if(xPos > 15)
            {
                xPos = -15;
                yPos -= 2;
                setX = 0;
                setY++;
            }
            //sets the first cube at position 0, 0 to be the active/red cube
            activeCube = cubeGrid[0, 0];
        }
    }

    public void Update()
    {
        
    }
}
