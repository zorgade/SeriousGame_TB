using Prototype.NetworkLobby;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameBoardScript : NetworkBehaviour
{

    /*public Text[] order;
    public Text scoreNumber;

    List<Player> players = new List<Player>();
    public static List<LobbyPlayer> _players = new List<LobbyPlayer>();

    public static int nbrePlayer;
    public static int count;

    public static GameObject[] allCase;

    public static int score = 0;
    public static int oldScore = 0;

    public Text diceScore;
    LobbyPlayer lobby;

    // Use this for initialization
    void Start()
    {
        nbrePlayer = 1;
        var playerName = lobby.playerName;

        Debug.Log("Network player : -> "+nbrePlayer);

        if (nbrePlayer != 1)
        {
            Debug.Log("BOARD " + nbrePlayer);
            //Sort descending the player by score and show the order
            players = players.OrderByDescending(x => x.score).ToList();
            for (int i = 0; i < nbrePlayer; i++)
            {
                order[i].text = players[i].Pseudo + " : " + players[i].score;
                Debug.Log(players[i].Pseudo + " : " + players[i].score);
            }
        }
        else
        {
            //players = ChoosePseudo.players;
            order[0].text = playerName;//players[0].Pseudo;// + " : " + players[0].score;

        }

        allCase = GameObject.FindGameObjectsWithTag("Case");
        allCase = allCase.OrderBy(x => x.name).ToArray();
        allCase[oldScore].GetComponent<Renderer>().material.color = Color.black;
    }

    public static void GetScore()
    {
        //var rndNumber = Random.Range(1, 6);
        allCase[score].GetComponent<Renderer>().material.color = Color.white;
        //allCase[oldScore].GetComponent<Renderer>().material.color = Color.white;
        oldScore = score;
        score += DiceGB.finalSide;
        //random = DiceGB.finalSide;

        if (score > allCase.Length-1)
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
        allCase[oldScore].GetComponent<Renderer>().material.color = Color.black;

        if (allCase[allCase.Length-1].GetComponent<Renderer>().material.color == Color.magenta)
        {
            SceneManager.LoadScene("10.End");
        }
    }*/


}

