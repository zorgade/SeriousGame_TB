using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectNbrePlayer : MonoBehaviour {

    public Button btn1;
    public Button btn2;
    public Button btn3;
    public Button btn4;
    
    public static int nbrePlayer;


    // Use this for initialization
    void Start () {


    }


    public void EnableInputField(int nbPlayer)
    {
        nbrePlayer = nbPlayer;
    }

    // Update is called once per frame
    void Update () {

    }
}