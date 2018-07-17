using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class DiceGB : MonoBehaviour
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
        PlayerPrefs.SetInt("playerScore", scorePlayer);

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
        if (SelectNbrePlayer.nbrePlayer != 1)
        {
            score.text = finalSide.ToString();
           
            oldScore = scorePlayer;
            scorePlayer += finalSide;
            if (scorePlayer >= BManager.allCase.Length - 1)
            {
                scorePlayer = BManager.allCase.Length - 1;
            }

            PlayerPrefs.SetInt("playerScore", scorePlayer);
            PlayerPrefs.SetInt("palyerOldScore", oldScore);
           
            Debug.Log(BManager.allCase.Length);

            BManager.allCase[scorePlayer].GetComponent<Renderer>().material.color = Color.white;
            BManager.allCase[oldScore].GetComponent<Renderer>().material.color = Color.white;

            BManager.allCase[scorePlayer].GetComponent<Renderer>().material.color = Color.magenta;
            BManager.allCase[oldScore].GetComponent<Renderer>().material.color = Color.black;
            

        }
        else
        {
            SoloBoardScript.GetScore();
        }
        Debug.Log(randomDiceSide + " -> " + finalSide);
    }
}
