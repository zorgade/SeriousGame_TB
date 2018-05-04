using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour {

    static Rigidbody rb;
    public static Vector3 diceVelocity;
    public float forceAmount = 10.0f;
    public float torqueAmount = 10.0f;
    public ForceMode forceMode;
    public static int countSpace;
    static bool played;


    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        countSpace = 0;
        played = false;
	}
	
	// Update is called once per frame
	void Update () {
        diceVelocity = rb.velocity;

        //Souris clique gauche = 0, clique droit=1. milieu=2
        if(Input.GetMouseButtonDown(0) && !played)
        {
            countSpace++;
            DiceNumberText.diceNumber = 0;
            float dirX = Random.Range(0, 500);
            float dirY = Random.Range(0, 500);
            float dirZ = Random.Range(0, 500);
            transform.position = new Vector3(2, 5, 0);
            transform.rotation = Quaternion.identity;
            //rb.AddForce(Random.onUnitSphere * forceAmount, forceMode);
            //rb.AddTorque(Random.onUnitSphere * torqueAmount, forceMode);
            rb.AddForce(transform.up * 500);
            rb.AddTorque(dirX, dirY, dirZ);
            played = true;
        }
	}
}
