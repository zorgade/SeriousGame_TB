using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class GameManager : NetworkBehaviour
{
    public static GameObject[] allCase;
    public static GameManager instance;
    Scene mScene;

    private void Awake()
    {


        allCase = GameObject.FindGameObjectsWithTag("Case");
        allCase = allCase.OrderBy(x => x.name).ToArray();
    }

    private void Start()
    {
        mScene = SceneManager.GetActiveScene();

    }

    void Update()
    {
        if (DiceGB.scorePlayer >= allCase.Length - 1)
        {
            DiceGB.scorePlayer = allCase.Length - 1;
            SceneManager.LoadScene("10.End");
        }
        allCase[DiceGB.scorePlayer].GetComponent<Renderer>().material.color = Color.magenta;
        allCase[DiceGB.oldScore].GetComponent<Renderer>().material.color = Color.black;

       /*if (mScene.name == "07.BoardGame")
        {
            foreach (GameObject go in allCase)
            {
                go.SetActive(true);
            }
        }*/
    }
}