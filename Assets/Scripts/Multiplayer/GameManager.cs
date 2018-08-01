using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class GameManager : NetworkBehaviour
{
    public static GameObject[] allCase;

    private void Awake()
    {
        allCase = GameObject.FindGameObjectsWithTag("Case");
        allCase = allCase.OrderBy(x => x.name).ToArray();
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
    }
}