using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public Vector3 scaleUp;
    public Vector3 scaleNorm;
    public int thisX, thisY;
    public int upX = 2, upY = 2, upZ = 2;
    public int normX = 1, normY = 1, normZ = 1;
    void Start()
    {
        scaleUp = new Vector3(upX, upY, upZ);
        scaleNorm = new Vector3(normX, normY, normZ);
    }
    public void OnMouseDown()
    {
        if (gameObject == GameController.activeCube && GameController.planeClicked == false)
        {
            GameController.planeClicked = true;
        }
        else if (gameObject == GameController.activeCube && GameController.planeClicked == true)
        {
            GameController.planeClicked = false;
            transform.localScale = scaleNorm;
        }
        else if (gameObject != GameController.activeCube && GameController.planeClicked == true)
        {
            GameController.targetCube = gameObject;
            GameController.targetX = thisX;
            GameController.targetY = thisY;
        }
    }
    void Update()
    {
        if(gameObject == GameController.activeCube)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.red;
            if(GameController.planeClicked == true)
            {
                transform.localScale = scaleUp;
            }
        }
        else if(gameObject == GameController.unloadCube && gameObject != GameController.activeCube)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.black;
            transform.localScale = scaleNorm;
        }
        else if(gameObject == GameController.targetCube && gameObject != GameController.activeCube)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.yellow;
            transform.localScale = scaleNorm;
        }
        else
        {
            gameObject.GetComponent<Renderer>().material.color = Color.white;
            transform.localScale = scaleNorm;
        }
    }
}
