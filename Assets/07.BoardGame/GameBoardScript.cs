using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameBoardScript : MonoBehaviour
{

    public Text[] order;
    public Text scoreNumber;

    List<Player> players = new List<Player>();
    public static int nbrePlayer;
    public static int count;

    public static GameObject[] allCase;

    public static int score = 0;
    public static int oldScore = 0;

    public Text diceScore;
    int random;


    // Use this for initialization
    void Start()
    {
        players = Dice.players;
        nbrePlayer = ChoosePseudo.nbrePlayers;

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
            players = ChoosePseudo.players;
            order[0].text = players[0].Pseudo;// + " : " + players[0].score;

        }

        allCase = GameObject.FindGameObjectsWithTag("Case");
        allCase = allCase.OrderBy(x => x.name).ToArray();
        //allCase[score].GetComponent<Renderer>().material.color = Color.magenta;
    }

    public void GetScore()
    {
        var rndNumber = Random.Range(1, 6);
        allCase[score].GetComponent<Renderer>().material.color = Color.white;
        //allCase[oldScore].GetComponent<Renderer>().material.color = Color.white;
        oldScore = score;
        score = score + rndNumber;
        random = rndNumber;

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
        diceScore.text = random.ToString();
        scoreNumber.text = score.ToString();
        allCase[oldScore].GetComponent<Renderer>().material.color = Color.black;

        if (allCase[allCase.Length-1].GetComponent<Renderer>().material.color == Color.magenta)
        {
            SceneManager.LoadScene("10.End");
        }
    }
}
