using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject cubePrefab;
    public static GameObject activeCube;
    public Vector3 cubePos;
    public float xPos;
    public float yPos;

    public void Start()
    {
        xPos = -15;
        yPos = 0;
        //Spawns 16 cubes in a row
        for (int x = 0; x < 16; x++)
        {
            cubePos = new Vector3(xPos, yPos, 0);
            Instantiate(cubePrefab, cubePos, Quaternion.identity);
            xPos += 2;
        }
    }

    public void Update()
    {
        
    }
}
