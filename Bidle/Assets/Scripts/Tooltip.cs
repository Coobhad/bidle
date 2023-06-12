using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tooltip : MonoBehaviour
{
    public GameObject tt;

    void OnMouseOver()
    {
        Debug.Log("mouse is on");
    }

    void OnMouseExit()
    {
        Debug.Log("mouse left");
    }
}
