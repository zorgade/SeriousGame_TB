using Prototype.NetworkLobby;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BManager : MonoBehaviour
{

    //this will get called when you click on the gameObject
    /* [SyncVar]
     public Color cubeColor;
     [SyncVar]
     private GameObject objectID;
     private NetworkIdentity objNetId;*/

    //public Text[] order;
    //public static int nbrePlayer;
    //private List<GameObject> allCase;
    //[SyncVar] private SyncList<GameObject> allCase;

    //public Text diceScore;
    //[SyncVar] private Color objectColor;
    //public static int testScore;
    //LobbyPlayer lobby;

    public Text[] playerName;

    public static PlayerPrefs palyerScore;

    public static GameObject[] allRows;
    public static GameObject map;

    public static int score = 0;
    public static int oldScore = 0;

    public static GameObject[] allCase;
    private static BManager instance = null;

    private void Awake()
    {
        allCase = GameObject.FindGameObjectsWithTag("Case");
        allCase = allCase.OrderBy(x => x.name).ToArray();
        allCase[DiceGB.scorePlayer].GetComponent<Renderer>().material.color = Color.magenta;
        allCase[DiceGB.oldScore].GetComponent<Renderer>().material.color = Color.black;


        Debug.Log("Awake: is called");
        for (int i = 0; i < allCase.Length; i++)
        {
            var instance = allCase[i];
            if (instance == null)
            {
                //if not, set instance to this
                instance = allCase[i];
            }
            //If instance already exists and it's not this:
            else if (instance != allCase[i])
            {
                //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
                Destroy(allCase[i].gameObject);
                Destroy(allCase[i].GetComponent<GameObject>());

            }
            //Sets this to not be destroyed when reloading scene
            //DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(allCase[i].gameObject);
            DontDestroyOnLoad(allCase[i].GetComponent<GameObject>());
            //DontDestroyOnLoad(allCase[i].GetComponent<Renderer>());

            

        }
        DontDestroyOnLoad(this);
        //DontDestroyOnLoad(allCase[5]);
        //allCase[5].GetComponent<Renderer>().material.color = Color.magenta;

    }

    private void Start()
    {
        /*foreach (GameObject go in allCase)
        {
            go.GetComponent<GameObject>();
        }*/
        // allCase = GameObject.FindGameObjectsWithTag("Case");
        //allCase = allCase.OrderBy(x => x.name).ToArray();

        // Int32.TryParse(scoreDisplay.text, out test);



        // score = PlayerPrefs.GetInt("playerScore");
        // oldScore = PlayerPrefs.GetInt("playerOldScore");
    }

    void Update()
    {/*
        if (!isLocalPlayer)
        {
            return;
        }*/
        allCase[DiceGB.scorePlayer].GetComponent<Renderer>().material.color = Color.magenta;
        allCase[DiceGB.oldScore].GetComponent<Renderer>().material.color = Color.black;

        if (DiceGB.scorePlayer >= allCase.Length - 1)
        {
            SceneManager.LoadScene("10.End");
        }
    }
}