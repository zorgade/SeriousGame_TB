using Prototype.NetworkLobby;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BManager : NetworkBehaviour
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

    public Text scoreDisplay;
    public Text[] playerName;

    public static PlayerPrefs palyerScore;

    public static GameObject[] allCase;
    public static GameObject[] allRows;
    public static GameObject map;

    public static int score = 0;
    public static int oldScore = 0;
    LobbyPlayer ni;

    private void Awake()
    {
        PlayerPrefs.SetInt("playerScore", 0);

        allCase = GameObject.FindGameObjectsWithTag("Case");
        allCase = allCase.OrderBy(x => x.name).ToArray();
        foreach (GameObject go in allCase)
        {
            DontDestroyOnLoad(go.GetComponent<GameObject>());
        }
        /*allRows = GameObject.FindGameObjectsWithTag("Row");
        allRows = allRows.OrderBy(x => x.name).ToArray();
        foreach (GameObject go in allRows)
        {
            DontDestroyOnLoad(go.GetComponent<GameObject>());
        }
        map = GameObject.FindGameObjectWithTag("Map");
        DontDestroyOnLoad(map);*/
        DontDestroyOnLoad(gameObject);
        allCase[oldScore].GetComponent<Renderer>().material.color = Color.black;


    }
    private void Start()
    {
      
        allCase = GameObject.FindGameObjectsWithTag("Case");
        allCase = allCase.OrderBy(x => x.name).ToArray();
        score = PlayerPrefs.GetInt("playerScore");
        oldScore = PlayerPrefs.GetInt("playerOldScore");


    }
    void Update()
    {
        //allCase[testScore].GetComponent<Renderer>().material.color = Color.magenta;

        if (!isLocalPlayer)
        {
            return;
        }
        if (score >= allCase.Length - 1)
        {
            score = allCase.Length - 1;
            SceneManager.LoadScene("10.End");
        }

    }
    public static void GetScore()
    {
        //allCase[score].GetComponent<Renderer>().material.color = Color.white;
        allCase[oldScore].GetComponent<Renderer>().material.color = Color.white;
        oldScore = score;
        score += DiceGB.finalSide;

        //Set Player score in PlayerPref
        PlayerPrefs.SetInt("playerScore", score);
        PlayerPrefs.SetInt("palyerOldScore", oldScore);
        Debug.Log(PlayerPrefs.GetInt("playerScore"));

        allCase[score].GetComponent<Renderer>().material.color = Color.magenta;
        allCase[oldScore].GetComponent<Renderer>().material.color = Color.black;
        
    }
  
       
    /*       CheckIfClicked();

       }
       GameObject[] FindObsWithTag(string tag)
       {
           GameObject[] foundObs = GameObject.FindGameObjectsWithTag(tag);
           Array.Sort(foundObs, CompareObNames);
           return foundObs;
       }

       int CompareObNames(GameObject x, GameObject y)
       {
           return x.name.CompareTo(y.name);
       }

       void CheckIfClicked()
       {
           if (Input.GetMouseButtonDown(0))
           {
               oldScore = score;
               score = DiceGB.finalSide;
               allCase[3].GetComponent<Renderer>().material.color = Color.black;

               objectID = allCase[0];
               //objectID = GameObject.FindGameObjectsWithTag("Case")[0];
               Debug.Log("Old score: "+oldScore);//get the tower                                   
               cubeColor = Color.black;   // I select the color here before doing anything else
               CmdChangeColor(objectID, cubeColor);
               objectID = allCase[1];//GameObject.FindGameObjectsWithTag("Case")[5];                         //get the tower                                   
               cubeColor = Color.magenta;   // I select the color here before doing anything else
               CmdChangeColor(objectID, cubeColor);
           }
       }



       [Command]
       void CmdChangeColor(GameObject go, Color c)
       {
           objNetId = go.GetComponent<NetworkIdentity>();        // get the object's network ID
           objNetId.AssignClientAuthority(connectionToClient);    // assign authority to the player who is changing the color
           RpcUpdateCube(go, c);
           // use a Client RPC function to "paint" the object on all clients
           objNetId.RemoveClientAuthority(connectionToClient);    // remove the authority from the player who changed the color
       }

       [ClientRpc]
       void RpcUpdateCube(GameObject go, Color c)
       {
           go.GetComponent<Renderer>().material.color = c;
       }*/
    // Use this for initialization
    /*void Start()
    {
        NetworkManager nm = FindObjectOfType<NetworkManager>();
        nbrePlayer = nm.numPlayers;
        var playerName = lobby.playerName;

        Debug.Log("Network player : -> " + nbrePlayer);

        Debug.Log("BOARD " + nbrePlayer);

        allCase.AddRange(GameObject.FindGameObjectsWithTag("Case"));

        objectID = allCase[oldScore];
        objectID = GameObject.FindGameObjectWithTag("Fire");// this gets the object that is hit
        objectColor = Color.black;    // I select the color here before doing anything else
        CmdPaint(objectID, objectColor);
    }*/
}




/* // Update is called once per frame
 void Update()
 {
     CheckIfPainting();

     diceScore.text = DiceGB.finalSide.ToString();
     scoreNumber.text = score.ToString();
 }

 void CheckIfPainting()
 {
     if (Input.GetMouseButtonDown(0))
     {
         Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
         RaycastHit hit;

         if (Physics.Raycast(ray, out hit, 1000))
         {
             objectID = GameObject.Find(hit.transform.name);                                    // this gets the object that is hit
             objectColor = Color.magenta;    // I select the color here before doing anything else
             CmdPaint(objectID, objectColor);
         }
     }
 }
 [ClientRpc]
 void RpcPaint(GameObject obj, Color col)
 {
     obj.GetComponent<Renderer>().material.color = col;        // this is the line that actually makes the change in color happen
 }

 [Command]
 void CmdPaint(GameObject obj, Color col)
 {
     objNetId = obj.GetComponent<NetworkIdentity>();        // get the object's network ID
     objNetId.AssignClientAuthority(connectionToClient);    // assign authority to the player who is changing the color
     RpcPaint(obj, col);                                    // usse a Client RPC function to "paint" the object on all clients
     objNetId.RemoveClientAuthority(connectionToClient);    // remove the authority from the player who changed the color
 }
}*/
