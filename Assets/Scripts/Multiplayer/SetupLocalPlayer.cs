using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SetupLocalPlayer : NetworkBehaviour
{

    [SyncVar]
    public string pname = "player";
    [SyncVar]
    public Color playerColor = Color.white;
    /*[SyncVar]
    public static int score;
    [SyncVar]
    public static int oldScore;*/

    [Command]
    private void CmdChangeName(string newName)
    {
        pname = newName;
        this.GetComponentInChildren<TextMesh>().text = pname;
    }

    private void Start()
    {
        if (isLocalPlayer)
        {
            Renderer[] rends = GetComponentsInChildren<Renderer>();
            foreach (Renderer r in rends)
            {
                r.material.color = playerColor;
            }
        }
    }

    private void Update()
    {
        this.GetComponentInChildren<TextMesh>().text = pname;
    }
}
