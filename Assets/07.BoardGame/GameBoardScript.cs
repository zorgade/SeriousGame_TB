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

    public static GameObject[] allCase;
    List<Case> cases;
    
    private int score = 0;
    private int oldScore;
    Random rnd = new Random();
    private bool canClick;
    Vector3 newPosition;


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

        allCase = GameObject.FindGameObjectsWithTag("Case");
        allCase = allCase.OrderBy(x => x.name).ToArray();
        //allCase[1].GetComponent<Renderer>().material.color = Color.magenta;

    }

    public void GetScore()
    {
        var rnd = Random.Range(1,6);
        oldScore = score;
        score = score + rnd; //DiceBoardGame.diceNumber;
        if(score >= allCase.Length - 1)
        {
            score = allCase.Length - 1;
        }
        Debug.Log(rnd);
    }

    // Update is called once per frame
    void Update()
    {
        score = DiceBoardGame.diceNumber;
        allCase[score].GetComponent<Renderer>().material.color = Color.magenta;
        allCase[oldScore].GetComponent<Renderer>().material.color = Color.white;

       
        //players[0].score = 0;
        //order[0].text = players[0].Pseudo + " : " + players[0].score;

    }
}
