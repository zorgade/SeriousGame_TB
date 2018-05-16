using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameBoardScript : MonoBehaviour
{

    public Text[] order;
    List<Player> players = new List<Player>();
    public static int nbrePlayer;
    public static int count;




    // Use this for initialization
    void Start()
    {
        nbrePlayer = Dice.nbrePlayer;
        players = Dice.players;
        //Sort descending the player by score and show the order
        players = players.OrderByDescending(x => x.score).ToList();
        for (int i = 0; i <= players.Count-1; i++)
        {
            order[i].text = players[i].Pseudo + " : " + players[i].score;
            Debug.Log(players[i].Pseudo + " : " + players[i].score);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //players[0].score = 0;
        //order[0].text = players[0].Pseudo + " : " + players[0].score;

    }
}
