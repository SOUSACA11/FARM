using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSize : MonoBehaviour
{
    void Start()
    {
        //Vector3 bottomLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
        //Vector3 topLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, Camera.main.nearClipPlane));
        //Vector3 bottomRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, Camera.main.nearClipPlane));
        //Vector3 topRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.nearClipPlane));

        //Debug.Log("Bottom-Left: " + bottomLeft); //-8.89, -0.58, -9.70
        //Debug.Log("Top-Left: " + topLeft); //-8.89, 9.42, -9.70
        //Debug.Log("Bottom-Right: " + bottomRight); //8.89, -0.58, -9.70
        //Debug.Log("Top-Right: " + topRight); //8.89, 9.42, -9.70
    }
}
