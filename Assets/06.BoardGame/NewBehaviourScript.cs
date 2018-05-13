using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour {


    public Text text1;
    public Text text2;
    public Text text3;
    public Text text4;

    // Use this for initialization
    void Start () {

        text1.text = ChoosePseudo.players[0].Pseudo + " :" + ChoosePseudo.players[0].score;
        text2.text = ChoosePseudo.players[1].Pseudo + " :" + ChoosePseudo.players[1].score;
        text3.text = ChoosePseudo.players[2].Pseudo + " :" + ChoosePseudo.players[2].score;
        text4.text = ChoosePseudo.players[3].Pseudo + " :" + ChoosePseudo.players[3].score;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
