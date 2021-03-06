﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoloDiceGB : MonoBehaviour
{
    private Sprite[] diceSides;
    public static int finalSide = 0;
    public Collider dieCollider;

    private SpriteRenderer rend;

    // Use this for initialization
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        dieCollider = this.GetComponent<Collider>();
        //chargement image dossier Resources > DiceSides
        diceSides = Resources.LoadAll<Sprite>("DiceSides/");
    }

    private void OnMouseDown()
    {
        //désactive après un clique
        dieCollider.enabled = !dieCollider.enabled;
        StartCoroutine("RollTheDice");
    }

    private IEnumerator RollTheDice()
    {
        int randomDiceSide = 0;

        for (int i = 0; i <= 20; i++)
        {
            randomDiceSide = Random.Range(0, 6);
            rend.sprite = diceSides[randomDiceSide];

            yield return new WaitForSeconds(0.05f);
        }
        finalSide = randomDiceSide + 1;
        SoloBoardScript.GetScore();

        Debug.Log(randomDiceSide + " -> " + finalSide);
    }
}