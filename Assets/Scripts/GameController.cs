using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject cubePrefab;
    public static GameObject activeCube;
    public static GameObject unloadCube;
    public static GameObject targetCube;
    public Vector3 cubePos;
    public float xPos, yPos;
    public static GameObject[,] cubeGrid;
    public static int gridX, gridY;
    public static bool planeClicked = false;
    double turnDuration = 1.5, turnTimer = 1.5;
    int cargoStored = 0, cargoGained = 10, score = 0;
    int activeX = 0, activeY = 0;
    int unloadX = 15, unloadY = 8;
    public static int targetX = 0, targetY = 0;

    public void Start()
    {
        gridX = 16;
        gridY = 9;
        cubeGrid = new GameObject[gridX, gridY];
        xPos = -15;
        yPos = 9;
        for (int y = 0; y < gridY; y++)
        {
            for (int x = 0; x < gridX; x++)
            {
                cubePos = new Vector3(xPos, yPos, 0);
                cubeGrid[x, y] = Instantiate(cubePrefab, cubePos, Quaternion.identity);
                cubeGrid[x, y].GetComponent<CubeController>().thisX = x;
                cubeGrid[x, y].GetComponent<CubeController>().thisY = y;
                xPos += 2;
            }
            xPos = -15;
            yPos -= 2;
        }
        setCubes();
    }
    void setCubes()
    {
        activeCube = cubeGrid[activeX, activeY];
        unloadCube = cubeGrid[unloadX, unloadY];
        targetCube = cubeGrid[targetX, targetY];
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
        if (planeClicked == true && activeCube != targetCube)
        {
            if (targetY < activeY)
            {
                activeY--;
            }
            else if (targetY > activeY)
            {
                activeY++;
            }
            if (targetX < activeX)
            {
                activeX--;
            }
            else if (targetX > activeX)
            {
                activeX++;
            }
            activeCube = cubeGrid[activeX, activeY];
        }
        print("You are currently holding " + cargoStored + " tons of cargo.  Your score is " + score + ".");
    }

    public void Update()
    {
        if(Time.time >= turnTimer)
        {
            turnTimer += turnDuration;
            takeTurn();
        }
    }
}
