using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class DiceGB : NetworkBehaviour
{

    private Sprite[] diceSides;
    public static int finalSide = 0;
    public Collider dieCollider;
    private SpriteRenderer rend;
    public Text score;
    public static int scorePlayer = 0;
    public static int oldScore = 0;

    private void Awake()
    {

    }
    // Use this for initialization
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        dieCollider = this.GetComponent<Collider>();
        diceSides = Resources.LoadAll<Sprite>("DiceSides/");
    }

    private void OnMouseDown()
    {
        //dieCollider.enabled = !dieCollider.enabled;
        StartCoroutine("RollTheDice");
    }

    private IEnumerator RollTheDice()
    {
        int randomDiceSide = 0;

        for (int i = 0; i <= 20; i++)
        {
            randomDiceSide = UnityEngine.Random.Range(0, 5);
            rend.sprite = diceSides[randomDiceSide];

            yield return new WaitForSeconds(0.05f);
        }
        finalSide = randomDiceSide + 1;


        score.text = finalSide.ToString();

        oldScore = scorePlayer;
        scorePlayer += finalSide;

        PlayerPrefs.SetInt("playerScore", scorePlayer);
        PlayerPrefs.SetInt("palyerOldScore", oldScore);
        Debug.Log(randomDiceSide + " -> " + finalSide);
    }
}
