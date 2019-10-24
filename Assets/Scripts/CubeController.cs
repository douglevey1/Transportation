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
        //sets scaling
        scaleUp = new Vector3(upX, upY, upZ);
        scaleNorm = new Vector3(normX, normY, normZ);
    }
    public void OnMouseDown()
    {
        //if the clicked cube is red, it will enlarge and open up to being moved through planeClicked
        if (gameObject == GameController.activeCube && GameController.planeClicked == false)
        {
            GameController.planeClicked = true;
            transform.localScale += scaleUp;
        }
        //if the red cube is already enlarged and is clicked on again, it will size back down and will not be moved if a different cube is clicked
        else if(gameObject == GameController.activeCube && GameController.planeClicked == true)
        {
            GameController.planeClicked = false;
            transform.localScale = scaleNorm;
        }
        //if the object clicked is not the red cube, but the red cube is enlarged/active, the clicked cube will become the new red cube
        else if(gameObject != GameController.activeCube && GameController.planeClicked == true)
        {
            GameController.activeCube.transform.localScale = scaleNorm;
            GameController.activeCube = gameObject;
            GameController.planeClicked = false;
        }
    }
    void Update()
    {
        //constantly checks if each cube is the active cube or not, and if it is, it becomes red
        if(gameObject == GameController.activeCube)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
        else
        {
            gameObject.GetComponent<Renderer>().material.color = Color.white;
            transform.localScale = scaleNorm;
        }
    }
}
