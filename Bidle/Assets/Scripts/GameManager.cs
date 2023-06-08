using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.Audio;


public class GameManager : MonoBehaviour
{
    Belinda belinda;

    System.Random rnd = new System.Random();

    public int clicks;
    public int mPrgs;
    public float bpoints;
    public float bps;
    public int ballAmount;
    public int framesPassed;
    public float fadeDuration = 0.02f;

    private bool TextisVisible;

    public int[] inventory = new int[2];

    public Text bpsText;
    public Text clickText;
    public Text clickAmountText;
    public Text scoreText;

    public GameObject b;
    public GameObject cursorText;
    public GameObject screenBreakO;
    public VideoPlayer screenBreak;
    public AudioSource mauroYell;

    // Start is called before the first frame update
    void Awake()
    {
        Application.runInBackground = true;
        Application.targetFrameRate = 60;

        belinda = b.GetComponent<Belinda>();

        // ADD LOAD FUNCTION BEFORE BUILD !!!!
        scoreText.text = "";
        TextisVisible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (TextisVisible == false)
        {
            cursorText.transform.position = Input.mousePosition;
        }
        else if (TextisVisible)
        {
            framesPassed = 0;
        }

        UpdatePoints();

        clickText.text = "Bpoints: " + Abr(bpoints);
        bpsText.text = Abr(bps) + " Bpoints per second";

        //Activating Marouane
        if (inventory[4] >= 1)
        {
            mPrgs++;
            if (mPrgs >= (int)(7200 / (inventory[4] ^ 1 / 5)))
            {
                mPrgs = 0;
                bpoints = bpoints + ballAmount;
            }
        }

        // Activating Belinda
        if (inventory[3] >= 1)
        {
            if (belinda.isActive == false)
            {
                int x = rnd.Next(0, (int)(7200 / (inventory[3] ^ (1 / 3))));

                if (x == 0)
                {
                    Debug.Log("activated belinda");
                    belinda.Activate();
                }
            }

        }
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
        scoreText.text = TextisVisible ? "+" + (inventory[2] + 1) : "";
        if (TextisVisible)
        {
            cursorText.transform.position = Input.mousePosition;
            StartCoroutine(FadeOutCoroutine());
        }
    }

    public void BelindaClick()
    {
        belinda.reward = 10000 * (int)(Math.Pow(2, inventory[5]) + 1);
        bpoints = bpoints + belinda.reward;
        belinda.Deactivate();
    }

    public void UpdatePoints()
    {
        int m = inventory[0];
        float l = 1 + (float)inventory[1] / 10;
        bps = m * l;
        bpoints = bpoints + bps / 60;

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

        clicks = PlayerPrefs.GetInt("Clicks");
    }

    // number formatting
    public string Abr(float num)
    {
        string s = "abr error";

        if (num >= 1000000000000000)
        {
            s = Math.Round(num / 1000000000000000, 2) + "Q";
        }

        if (num >= 1000000000000)
        {
            s = Math.Round(num / 1000000000000, 2) + "T";
        }

        if (num >= 1000000000)
        {
            s = Math.Round(num / 1000000000, 2) + "B";
        }

        if (num >= 1000000)
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
