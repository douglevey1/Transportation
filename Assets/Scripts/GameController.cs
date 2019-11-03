using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject cubePrefab;
    public static GameObject activeCube;
    public static GameObject unloadCube;
    public Vector3 cubePos;
    public float xPos, yPos;
    public static GameObject[,] cubeGrid;
    public static int gridX, gridY;
    public static bool planeClicked = false;
    int setX = 0, setY = 0;
    double turnDuration = 1.5, turnTimed = 0;
    int cargoStored = 0, cargoGained = 10, score = 0;

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
            setCubes();
        }
    }

    void setCubes()
    {
        //For some reason trying to set both colors here stops the program from spawning more than one cube
        activeCube = cubeGrid[0, 0];
        //activeCube.GetComponent<Renderer>().material.color = Color.red;
        unloadCube = cubeGrid[15, 8];
        //unloadCube.GetComponent<Renderer>().material.color = Color.black;
    }
    
    void takeTurn()
    {
        if(activeCube == cubeGrid[0, 0] && cargoStored < 90)
        {
            cargoStored += cargoGained;
        }
        else if(activeCube == unloadCube)
        {
            score += cargoStored;
            cargoStored = 0;
        }
        print("You are currently holding " + cargoStored + " tons of cargo.  Your score is " + score + ".");
    }

    public void Update()
    {
        if(Time.time >= turnTimed)
        {
            turnTimed += turnDuration;
            takeTurn();
        }
    }
}
