using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    void Start()
    {
        
    }
    public void OnMouseDown()
    {
        //If this game object is not activeCube, it will turn white
        if (GameController.activeCube != null)
        {
            GameController.activeCube.GetComponent<Renderer>().material.color = Color.white;
        }
        //Turns clicked cube red
        gameObject.GetComponent<Renderer>().material.color = Color.red;
        GameController.activeCube = gameObject;
    }
    void Update()
    {
        
    }
}
