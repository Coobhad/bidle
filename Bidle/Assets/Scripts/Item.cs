using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    GameManager gameManager;

    public float cost = 0;
    public int place = 0;
    public int counter = 0;
    public int baseCost = 0;
    public float multiplier = 0;

    public void Buy()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        if (gameManager.bpoints >= cost)
        {
            gameManager.bpoints = gameManager.bpoints - cost;
            gameManager.inventory[place]++;
            counter = gameManager.inventory[place];

            cost = (float)(baseCost * Math.Pow(multiplier, counter));
        }
    }
}