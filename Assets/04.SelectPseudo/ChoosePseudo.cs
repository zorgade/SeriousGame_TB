using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChoosePseudo : MonoBehaviour {

    public InputField[] pseudo = new InputField[4];
    public static int nbrePlayer;


    private void Awake()
    {

    }
    // Use this for initialization
    void Start () {

        nbrePlayer = SelectNbrePlayer.nbrePlayer;
        Debug.Log(nbrePlayer);
        for(int i=0; i< pseudo.Length; i++)
        {
            pseudo[i].GetComponent<InputField>();
        }
        EnableInputField(nbrePlayer);
    }

    // Update is called once per frame
    void Update () {
		
	}

    private void EnableInputField(int value)
    {
        Debug.Log("Value "+value);
        DisableInputField(false);
        for(int i = 0; i < value; i++)
        {
            pseudo[i].enabled = true;
        }


    }
    private void DisableInputField(bool value)
    {
            for(int i = 0; i < pseudo.Length; i++)
        {
            pseudo[i].enabled = false;
        }
    }
}
