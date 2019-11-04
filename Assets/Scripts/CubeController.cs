using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public Vector3 scaleUp;
    public Vector3 scaleNorm;
    public int upX = 1, upY = 1, upZ = 1;
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
            transform.localScale += scaleUp;
        }
        else
        {
            GameController.planeClicked = false;
            GameController.activeCube.transform.localScale = scaleNorm;
            transform.localScale = scaleNorm;
        }
    }
    void Update()
    {
        if(gameObject == GameController.activeCube)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
        else if(gameObject == GameController.unloadCube && gameObject != GameController.activeCube)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.black;
            transform.localScale = scaleNorm;
        }
        else
        {
            gameObject.GetComponent<Renderer>().material.color = Color.white;
            transform.localScale = scaleNorm;
        }
    }
}
