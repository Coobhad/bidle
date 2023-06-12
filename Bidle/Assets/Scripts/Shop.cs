using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{

    public GameObject x1;
    public GameObject x10;
    public GameObject x100;

    public Text x1Txt;
    public Text x10Txt;
    public Text x100Txt;

    private int xTimes = 1;

    GameManager gameManager;
    public GameObject g;

    public Item marouane = new Item();
    public Item niels = new Item();
    public Item mauro = new Item();
    public Item lucas = new Item();
    public Item ingmar = new Item();
    public Item belinda = new Item();
    public Item ball = new Item();

    public Text marouaneCost;
    public Text marouaneCounter;
    public GameObject marouaneSprite;

    public Text nielsCost;
    public Text nielsCounter;
    public GameObject nielsSprite;

    public Text mauroCost;
    public Text mauroCounter;
    public GameObject mauroSprite;

    public Text lucasCost;
    public Text lucasCounter;
    public GameObject lucasSprite;

    public Text ingmarCost;
    public Text ingmarCounter;
    public GameObject ingmarSprite;

    public Text belindaCost;
    public Text belindaCounter;

    public Text ballCost;
    public Text ballCounter;

    // Start is called before the first frame update
    void Start()
    {

        x1Txt = x1.GetComponent<Text>();
        x10Txt = x10.GetComponent<Text>();
        x100Txt = x100.GetComponent<Text>();

        gameManager = g.GetComponent<GameManager>();

        mauro.place = 0;
        mauro.baseCost = 15;
        mauro.multiplier = 1.07F;

        lucas.place = 1;
        lucas.baseCost = 100;
        lucas.multiplier = 1.09F;

        niels.place = 2;
        niels.baseCost = 1100;
        niels.multiplier = 1.25F;

        ingmar.place = 3;
        ingmar.baseCost = 12000;
        ingmar.multiplier = 1.12F;

        marouane.place = 4;
        marouane.baseCost = 130000;
        marouane.multiplier = 1.15F;

        belinda.place = 5;
        belinda.baseCost = 12000;
        belinda.multiplier = 1.19F;

        ball.place = 6;
        ball.baseCost = 72000;
        ball.multiplier = 1.2F;

        mauro.cost = (float)(mauro.baseCost * Math.Pow(mauro.multiplier, gameManager.inventory[0]));
        lucas.cost = (float)(lucas.baseCost * Math.Pow(lucas.multiplier, gameManager.inventory[1]));
        niels.cost = (float)(niels.baseCost * Math.Pow(niels.multiplier, gameManager.inventory[2]));
        ingmar.cost = (float)(ingmar.baseCost * Math.Pow(ingmar.multiplier, gameManager.inventory[3]));
        marouane.cost = (float)(marouane.baseCost * Math.Pow(marouane.multiplier, gameManager.inventory[4]));
        belinda.cost = (float)(belinda.baseCost * Math.Pow(belinda.multiplier, gameManager.inventory[5]));

        mauroCost.text = Abr(mauro.cost) + " BP";
        mauroCounter.text = Abr(gameManager.inventory[0]) + "";

        if (gameManager.inventory[0] >= 1)
        {
            mauroSprite.SetActive(true);
        }

        lucasCost.text = Abr(lucas.cost) + " BP";
        lucasCounter.text = Abr(gameManager.inventory[1]) + "";
        if (gameManager.inventory[1] >= 1)
        {
            lucasSprite.SetActive(true);
        }

        nielsCost.text = Abr(niels.cost) + " BP";
        nielsCounter.text = Abr(gameManager.inventory[2]) + "";
        if (gameManager.inventory[2] >= 1)
        {
            nielsSprite.SetActive(true);
        }

        ingmarCost.text = Abr(ingmar.cost) + " BP";
        ingmarCounter.text = Abr(gameManager.inventory[3]) + "";
        if (gameManager.inventory[3] >= 1)
        {
            ingmarSprite.SetActive(true);
        }

        marouaneCost.text = Abr(marouane.cost) + " BP";
        marouaneCounter.text = Abr(gameManager.inventory[4]) + "";
        if (gameManager.inventory[4] >= 1)
        {
            marouaneSprite.SetActive(true);
        }

        belindaCost.text = Abr(belinda.cost) + " BP";
        belindaCounter.text = Abr(gameManager.inventory[5]) + "";

        ballCost.text = Abr(ball.cost) + " BP";
        ballCounter.text = Abr(gameManager.inventory[6]) + "";
    }

    public void BuyMarouane()
    {
        int i = 0;
        while (i < xTimes)
        {
            marouane.Buy();
            i++;
        }
        marouaneCost.text = Abr(marouane.cost) + " BP";
        marouaneCounter.text = Abr(marouane.counter) + "";
        if (marouane.counter >= 1)
        {
            marouaneSprite.SetActive(true);
        }

    }

    public void BuyNiels()
    {
        int i = 0;
        while (i < xTimes)
        {
            niels.Buy();
            i++;
        }
        nielsCost.text = Abr(niels.cost) + " BP";
        nielsCounter.text = Abr(niels.counter) + "";
        if (niels.counter >= 1)
        {
            nielsSprite.SetActive(true);
        }

    }

    public void BuyMauro()
    {
        int i = 0;
        while (i < xTimes)
        {
            mauro.Buy();
            i++;
        }
        mauroCost.text = Abr(mauro.cost) + " BP";
        mauroCounter.text = Abr(mauro.counter) + "";

        if (mauro.counter >= 1)
        {
            mauroSprite.SetActive(true);
        }
    }

    public void BuyLucas()
    {
        int i = 0;
        while (i < xTimes)
        {
            lucas.Buy();
            i++;
        }
        lucasCost.text = Abr(lucas.cost) + " BP";
        lucasCounter.text = Abr(lucas.counter) + "";
        if (lucas.counter >= 1)
        {
            lucasSprite.SetActive(true);
        }

    }

    public void BuyIngmar()
    {
        int i = 0;
        while (i < xTimes)
        {
            ingmar.Buy();
            i++;
        }
        ingmarCost.text = Abr(ingmar.cost) + " BP";
        ingmarCounter.text = Abr(ingmar.counter) + "";
        if (ingmar.counter >= 1)
        {
            ingmarSprite.SetActive(true);
        }

    }

    public void BuyBelinda()
    {
        int i = 0;
        while (i < xTimes)
        {
            belinda.Buy();
            i++;
        }

        belindaCost.text = Abr(belinda.cost) + " BP";
        belindaCounter.text = Abr(belinda.counter) + "";

        gameManager.belinda.dissapearChance = (int)(4000 * (float)(Math.Pow(0.97, belinda.counter)));
    }

    public void BuyBall()
    {
        int i = 0;
        while (i < xTimes)
        {
            ball.Buy();
            i++;
        }
        ballCost.text = Abr(ball.cost) + " BP";
        ballCounter.text = Abr(ball.counter) + "";

    }

    public void BuyOnce()
    {
        xTimes = 1;

        x1Txt.color = Color.white;
        x10Txt.color = Color.grey;
        x100Txt.color = Color.grey;
    }

    public void BuyTen()
    {
        xTimes = 10;

        x1Txt.color = Color.grey;
        x10Txt.color = Color.white;
        x100Txt.color = Color.grey;
    }

    public void BuyHundred()
    {
        xTimes = 100;

        x1Txt.color = Color.grey;
        x10Txt.color = Color.grey;
        x100Txt.color = Color.white;
    }


    public string Abr(float num)
    {
        string s = "abr error";

        if (num >= 1000000000000000)
        {
            s = Math.Round(num / 1000000000000000, 2) + "Q";
        }

        else if (num >= 1000000000000)
        {
            s = Math.Round(num / 1000000000000, 2) + "T";
        }

        else if (num >= 1000000000)
        {
            s = Math.Round(num / 1000000000, 2) + "B";
        }

        else if (num >= 1000000)
        {
            s = Math.Round(num / 1000000, 2) + "M";
        }

        else if (num >= 1000)
        {
            s = Math.Round(num / 1000, 2) + "K";
        }
        else
        {
            s = (int)Math.Floor(num) + "";
        }
        return s;
    }
}

