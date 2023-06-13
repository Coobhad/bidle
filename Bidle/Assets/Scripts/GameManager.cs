using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.Audio;


public class GameManager : MonoBehaviour
{
    public Belinda belinda = new Belinda();

    System.Random rnd = new System.Random();

    public int clicks;
    public int mPrgs;
    public float bpoints;
    public float bps;
    public int framesPassed;
    public float fadeDuration = 0.02f;

    private bool TextisVisible;
    private bool isBallin = false;
    private bool mIdleStatePicked = false;

    public int[] inventory = new int[2];

    public Text bpsText;
    public Text clickText;
    public Text clickAmountText;
    public Text scoreText;

    private string marouaneIdleState;

    public GameObject cursorText;
    public GameObject screenBreakO;
    public GameObject belindaSprite;

    public GameObject marouaneSprite;
    private Animator ballin;

    public VideoPlayer screenBreak;

    public AudioSource mauroYell;
    public AudioSource belindaBark;
    public AudioSource belindaAppear;
    public AudioSource ballSound;

    void Awake()
    {
        Application.runInBackground = true;
        Application.targetFrameRate = 60;

        // ADD LOAD FUNCTION BEFORE BUILD !!!!
        Load();

        belinda.dissapearChance = (int)(4000 * (float)(Math.Pow(0.99, inventory[5])));
        scoreText.text = "";
        TextisVisible = false;

        ballin = marouaneSprite.GetComponent<Animator>();
    }


    void Update()
    {
        // initialises marouane animator
        if ((inventory[4] >= 1) && mIdleStatePicked == false && isBallin == false)
        {
            ballin = marouaneSprite.GetComponent<Animator>();
            marouaneIdleState = ballin.GetCurrentAnimatorClipInfo(0)[0].clip.name;
        }

        if (TextisVisible == false)
        {
            cursorText.transform.position = Input.mousePosition;
        }
        else if (TextisVisible)
        {
            framesPassed = 0;
        }

        UpdatePoints();

        clickText.text = Abr(bpoints) + " Bpoints";
        bpsText.text = Abr(bps) + " Bpoints per second";

        // Activating Marouane
        if (inventory[4] >= 1)
        {
            mPrgs++;
            if ((mPrgs == 30) && (isBallin == true))
            {
                ballin.Play(marouaneIdleState);
                isBallin = false;
            }
            if (mPrgs >= (int)(10000 / (float)Math.Pow(1.1, inventory[4])) + 40)
            {
                mPrgs = 0;
                bpoints = bpoints + 50000 * (float)(Math.Pow(1.2, inventory[6]));
                ballin.Play("Marouane Ballin", -1, 0f);
                ballSound.Play();
                isBallin = true;
            }
        }

        // Activating Belinda
        if (inventory[3] >= 1)
        {
            if (belinda.isActive == false)
            {
                int x = rnd.Next(0, (int)(7000 * (Math.Pow(0.98, inventory[3]))));

                if (x == 0)
                {
                    Debug.Log(belinda.dissapearChance);
                    int xCo = rnd.Next(300, 1200);
                    int yCo = rnd.Next(300, 700);

                    belindaSprite.transform.position = new Vector2(xCo, yCo);
                    SetBelindaSpriteActive(true);
                    belindaAppear.Play();
                    belinda.isActive = true;
                }
            }
            if (belinda.isActive == true)
            {
                int x = rnd.Next(0, belinda.dissapearChance);

                if (x == 0)
                {
                    SetBelindaSpriteActive(false);
                    belinda.isActive = false;
                }

            }

        }
        // Easter egg
        if (framesPassed >= 360000)
        {
            screenBreakO.SetActive(true);
            mauroYell.Play();
            screenBreak.Play();
            framesPassed = 0;
        }
        framesPassed++;
    }

    public void Click()
    {
        clicks++;
        clickAmountText.text = clicks + " CLICKS";
        bpoints = bpoints + inventory[2] + 1;

        TextisVisible = !TextisVisible;
        scoreText.text = TextisVisible ? "+" + Abr(inventory[2] + 1) : "";
        if (TextisVisible)
        {
            cursorText.transform.position = Input.mousePosition;
            StartCoroutine(FadeOutCoroutine());
        }

    }

    public void BelindaClick()
    {
        belindaBark.Play();

        belinda.reward = 10000 * (float)(Math.Pow(1.3, inventory[5]));
        bpoints = bpoints + belinda.reward;

        SetBelindaSpriteActive(false);
        belinda.isActive = false;
    }

    public void UpdatePoints()
    {
        int m = inventory[0];
        float l = 1 + (float)inventory[1] / 10;
        bps = m * l;
        bpoints = bpoints + bps / 60;

    }

    void SetBelindaSpriteActive(bool isActive)
    {
        belindaSprite.SetActive(isActive);
    }

    public void Save()
    {
        PlayerPrefs.SetFloat("Bpoints", bpoints);

        PlayerPrefs.SetInt("Mauro", inventory[0]);
        PlayerPrefs.SetInt("Lucas", inventory[1]);
        PlayerPrefs.SetInt("Niels", inventory[2]);
        PlayerPrefs.SetInt("Ingmar", inventory[3]);
        PlayerPrefs.SetInt("Marouane", inventory[4]);
        PlayerPrefs.SetInt("Belinda", inventory[5]);
        PlayerPrefs.SetInt("Ball", inventory[5]);

        PlayerPrefs.SetInt("Clicks", clicks);
    }

    public void Load()
    {
        bpoints = PlayerPrefs.GetFloat("Bpoints");

        inventory[0] = PlayerPrefs.GetInt("Mauro");
        inventory[1] = PlayerPrefs.GetInt("Lucas");
        inventory[2] = PlayerPrefs.GetInt("Niels");
        inventory[3] = PlayerPrefs.GetInt("Ingmar");
        inventory[4] = PlayerPrefs.GetInt("Marouane");
        inventory[5] = PlayerPrefs.GetInt("Belinda");
        inventory[6] = PlayerPrefs.GetInt("Ball");

        clicks = PlayerPrefs.GetInt("Clicks");
    }


    public void ClearSave()
    {
        PlayerPrefs.SetFloat("Bpoints", 0);

        PlayerPrefs.SetInt("Mauro", 0);
        PlayerPrefs.SetInt("Lucas", 0);
        PlayerPrefs.SetInt("Niels", 0);
        PlayerPrefs.SetInt("Ingmar", 0);
        PlayerPrefs.SetInt("Marouane", 0);
        PlayerPrefs.SetInt("Belinda", 0);
        PlayerPrefs.SetInt("Ball", 0);

        PlayerPrefs.SetInt("Clicks", 0);
    }
    // number formatting
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
    // +1 - fade
    private IEnumerator FadeOutCoroutine()
    {
        yield return new WaitForSeconds(fadeDuration);

        float elapsedTime = 0f;
        float fadeTime = 1f;

        while (elapsedTime < fadeTime)
        {
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeTime);
            scoreText.color = new Color(scoreText.color.r, scoreText.color.g, scoreText.color.b, alpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        scoreText.text = "";
        scoreText.color = new Color(scoreText.color.r, scoreText.color.g, scoreText.color.b, 1f);
        TextisVisible = false;
    }
}
