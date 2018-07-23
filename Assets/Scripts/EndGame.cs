using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{

    private GameObject LBM;
    void Start()
    {

        LBM = GameObject.Find("LobbyManager");
    }

    public void EndGameMenu()
    {
        Network.Disconnect();
        NetworkServer.Shutdown();
        GameObject[] GameObjects = (FindObjectsOfType<GameObject>() as GameObject[]);
        for (int i = 0; i < GameObjects.Length; i++)
        {
            Destroy(GameObjects[i]);
        }
        Network.Disconnect();
        SceneManager.LoadScene("02.Menu"); // SCENE SUIVANTE
    }
}
