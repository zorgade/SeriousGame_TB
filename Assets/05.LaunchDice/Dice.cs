using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dice : MonoBehaviour {

    static Rigidbody rb;
    public static Vector3 diceVelocity;
    public float forceAmount = 10.0f;
    public float torqueAmount = 10.0f;
    public ForceMode forceMode;
    public static int countSpace;
    static bool played;

    public static int nbrePlayer;
    public Text playerTour;
    public Text title;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        countSpace = 0;
        played = false;
        title.GetComponent<Text>();
        nbrePlayer = ChoosePseudo.nbrePlayer;
    }
	

	// Update is called once per frame
	void Update () {
        diceVelocity = rb.velocity;

        for (int i = 0; i < nbrePlayer; i++)
        {
            playerTour.text = ChoosePseudo.pseudoName[i].ToString();
            //Souris clique gauche = 0, clique droit=1. milieu=2
            if (Input.GetMouseButtonDown(0) && !played)
            {
                //played = false;
                Lauch();
                played = false;

            }
        }

	}
    void Lauch()
    {
        played = true;
        countSpace++;
        DiceNumberText.diceNumber = 0;
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
