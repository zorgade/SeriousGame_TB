using Prototype.NetworkLobby;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SoloBoardScript : MonoBehaviour
{
    public Text scoreNumber;
    public static GameObject[] allCase;

    public static int score = 0;
    public static int oldScore = 0;
    public static int totalScore = 0;

    private void Awake()
    {
        //Initialize and order case
        allCase = GameObject.FindGameObjectsWithTag("Case");
        allCase = allCase.OrderBy(x => x.name).ToArray();
    }
    // Use this for initialization
    void Start()
    {
        Debug.Log("CASE " + allCase.Length);
        allCase[oldScore].GetComponent<Renderer>().material.color = Color.black;

    }

    //2D dice score
    public static void GetScore()
    {
        allCase[score].GetComponent<Renderer>().material.color = Color.white;
        allCase[oldScore].GetComponent<Renderer>().material.color = Color.white;
        oldScore = score;
        score += SoloDiceGB.finalSide;
        totalScore += SoloDiceGB.finalSide;

        if (score > allCase.Length - 1)
        {
            score = allCase.Length - 1;
            SceneManager.LoadScene("10.End");

        }
        allCase[score].GetComponent<Renderer>().material.color = Color.magenta;
        allCase[oldScore].GetComponent<Renderer>().material.color = Color.black;

    }

    // Update is called once per frame
    void Update()
    {
        //Update totalScore to UI
        scoreNumber.text = totalScore.ToString();
    }
}

