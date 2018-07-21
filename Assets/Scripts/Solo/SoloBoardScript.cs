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
    public Text order;
    public Text scoreNumber;
    Player players;

    public static int count;

    public static GameObject[] allCase;

    public static int score = 0;
    public static int oldScore = 0;

    public Text diceScore;

    private void Awake()
    {
        allCase = GameObject.FindGameObjectsWithTag("Case");
        allCase = allCase.OrderBy(x => x.name).ToArray();
    }
    // Use this for initialization
    void Start()
    {
        players = ChoosePseudo.players[0];
        order.text = players.Pseudo;

        
        Debug.Log("CASE "+allCase.Length);
        allCase[score].GetComponent<Renderer>().material.color = Color.magenta;
        allCase[oldScore].GetComponent<Renderer>().material.color = Color.black;

    }

    public static void GetScore()
    {
        //var rndNumber = Random.Range(1, 6);
        allCase[score].GetComponent<Renderer>().material.color = Color.white;
        allCase[oldScore].GetComponent<Renderer>().material.color = Color.white;
        oldScore = score;
        score += SoloDiceGB.finalSide;
        //random = DiceGB.finalSide;

        if (score > allCase.Length - 1)
        {
            score = allCase.Length - 1;
        }
        allCase[score].GetComponent<Renderer>().material.color = Color.magenta;
        allCase[oldScore].GetComponent<Renderer>().material.color = Color.black;

    }

    // Update is called once per frame
    void Update()
    {
        diceScore.text = DiceGB.finalSide.ToString();
        scoreNumber.text = score.ToString();
        //allCase[oldScore].GetComponent<Renderer>().material.color = Color.black;

        if (allCase[allCase.Length - 1].GetComponent<Renderer>().material.color == Color.magenta)
        {
            SceneManager.LoadScene("10.End");
        }
    }


}

