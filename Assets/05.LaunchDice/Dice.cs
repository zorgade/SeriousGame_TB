using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Dice : MonoBehaviour
{

    static Rigidbody rb;
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

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        countSpace = 0;
        nbrePlayer = ChoosePseudo.nbrePlayer;
        count = 0;
        _player = ChoosePseudo.players[count];
        btn.gameObject.SetActive(false);
        

    }

    // Update is called once per frame
    private void Update()
    {
        if (ChoosePseudo.players[nbrePlayer - 1].score <= 0)
        {

            diceVelocity = rb.velocity;
            playerName.text = ChoosePseudo.players[count].Pseudo;

            if (Input.GetMouseButtonDown(0) && _player.played == false)
            {
                Launch();
            }
            if (_player.played == true && diceVelocity.x == 0f && diceVelocity.y == 0f && diceVelocity.z == 0f)
            {
                _player.score = diceNumber;
                score[count].text = playerName.text +" : "+ ChoosePseudo.players[count].score;
                Initialize();
            }
        }
    }

    void Initialize()
    {
        if (count < nbrePlayer && diceNumber != 0)
        {
            diceNumber = 0;
            if (ChoosePseudo.players[(nbrePlayer - 1)].score > 0)
            {
                btn.gameObject.SetActive(true);
            }
            count++;
            _player = ChoosePseudo.players[count];
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
