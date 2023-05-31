using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Belinda : MonoBehaviour
{
    public GameObject belinda;
    public bool isActive;
    System.Random rnd = new System.Random();

    public int dissapearChance;
    public float reward;

    public void Activate()
    {
        int x = rnd.Next(300, 1200);
        int y = rnd.Next(300, 700);

        belinda.transform.position = new Vector2(x, y);
        belinda.SetActive(true);
        isActive = true;
    }

    public void Deactivate()
    {
        belinda.SetActive(false);
        isActive = false;
    }

    private void Update()
    {
        if (isActive == false)
        {
            float x = rnd.Next(0, dissapearChance);

            if (x == 0)
            {
                belinda.SetActive(false);
                isActive = false;
            }

        }
    }
}