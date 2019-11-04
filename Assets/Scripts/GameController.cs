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
    double turnDuration = 1.5, turnTimer = 1.5;
    int cargoStored = 0, cargoGained = 10, score = 0;
    int activeX = 0, activeY = 0;
    int unloadX = 15, unloadY = 8;

    public void Start()
    {
        gridX = 16;
        gridY = 9;
        cubeGrid = new GameObject[gridX, gridY];
        xPos = -15;
        yPos = 9;
        for (int x = 0; x < (gridX * gridY); x++)
        {
            cubePos = new Vector3(xPos, yPos, 0);
            cubeGrid[setX, setY] = Instantiate(cubePrefab, cubePos, Quaternion.identity);
            xPos += 2;
            setX++;
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
        activeCube = cubeGrid[activeX, activeY];
        unloadCube = cubeGrid[unloadX, unloadY];
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
        if(Time.time >= turnTimer)
        {
            turnTimer += turnDuration;
            takeTurn();
        }
        if(planeClicked == true)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown("w"))
            {
                activeY--;
                planeClicked = false;
            }
            else if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown("a"))
            {
                activeX--;
                planeClicked = false;
            }
            else if(Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown("s"))
            {
                activeY++;
                planeClicked = false;
            }
            else if(Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown("d"))
            {
                activeX++;
                planeClicked = false;
            }
        }
        if(activeX > 15)
        {
            activeX = 15;
        }
        else if(activeX < 0)
        {
            activeX = 0;
        }
        if(activeY > 8)
        {
            activeY = 8;
        }
        else if(activeY < 0)
        {
            activeY = 0;
        }
        activeCube = cubeGrid[activeX, activeY];
    }
}
