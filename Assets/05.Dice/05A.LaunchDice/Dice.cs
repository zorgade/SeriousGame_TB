using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Dice : MonoBehaviour
{

    public static Rigidbody rb;
    public static Vector3 diceVelocity;
    public float forceAmount = 10.0f;
    public float torqueAmount = 10.0f;
    public ForceMode forceMode;
    public static int countSpace;

    public static int nbrePlayer;
    public Text playerName;
    public static int count;
    Player _player;

    public static int diceNumber = 0;
    public Button btn;
    public Text[] score;
    public static List<Player> players = new List<Player>();


    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        countSpace = 0;
        nbrePlayer = ChoosePseudo.nbrePlayers;
        players = ChoosePseudo.players;
        count = 0;
        _player = players[count];
        btn.gameObject.SetActive(false);
        

    }

    // Update is called once per frame
    private void Update()
    {
        if (players[nbrePlayer - 1].score <= 0)
        {
            diceVelocity = rb.velocity;
            playerName.text = players[count].Pseudo;

            if (Input.GetMouseButtonDown(0) && _player.played == false)
            {
                Launch();
            }
            if (_player.played == true && diceVelocity.x == 0f && diceVelocity.y == 0f && diceVelocity.z == 0f)
            {
                _player.score = diceNumber;
                score[count].text = playerName.text +" : "+ players[count].score;
                Initialize();
            }
        }
        /*else
        {
            if(nbrePlayer > 1)
            {
                int index = 0;

                foreach (var item in players)
                {
                    int[] scoreControl = new int[nbrePlayer];
                    item.score = scoreControl[index];
                    index++;
                    for(int i=0; i <= index; i++)
                    {

                    }
                }
                
            }
        }*/
    }

    void Initialize()
    {
        if (count < nbrePlayer && diceNumber != 0)
        {
            diceNumber = 0;
            if (players[(nbrePlayer - 1)].score > 0)
            {
                btn.gameObject.SetActive(true);
                count = nbrePlayer - 1;
                return;
            }
            count++;
            _player = players[count];
            return;
        }

    }
    void Launch()
    {
        countSpace++;
        _player.played = true;
        diceNumber = 0;
        float dirX = Random.Range(0, 500);
        float dirY = Random.Range(0, 500);
        float dirZ = Random.Range(0, 500);
        transform.position = new Vector3(2, 5, 0);
        transform.rotation = Quaternion.identity;
        rb.AddForce(Random.onUnitSphere * forceAmount, forceMode);
        rb.AddTorque(Random.onUnitSphere * torqueAmount, forceMode);
        rb.AddForce(transform.up * 100);
        rb.AddTorque(dirX, dirY, dirZ);
    }
}