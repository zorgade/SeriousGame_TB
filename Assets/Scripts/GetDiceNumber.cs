using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetDiceNumber : MonoBehaviour {

    Vector3 diceVelocity;
    public static int diceNumber;

    private void FixedUpdate()
    {
        diceVelocity = Dice.diceVelocity;
    }

    private void OnTriggerStay(Collider col)
    {
        if (Dice.countSpace > 0) {
            if (diceVelocity.x == 0f && diceVelocity.y == 0f && diceVelocity.z == 0f)
            {
                switch (col.gameObject.name)
                {
                    case "Side1":
                        Dice.diceNumber = 6;
                        break;
                    case "Side2":
                        Dice.diceNumber = 5;
                        break;
                    case "Side3":
                        Dice.diceNumber = 4;
                        break;
                    case "Side4":
                        Dice.diceNumber = 3;
                        break;
                    case "Side5":
                        Dice.diceNumber = 2;
                        break;
                    case "Side6":
                        Dice.diceNumber = 1;
                        break;
                }

            }
        }
        else {
            Dice.diceNumber = 0;
        }

    }
}
