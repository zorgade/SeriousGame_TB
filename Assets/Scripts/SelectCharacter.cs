using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectCharacter : MonoBehaviour
{

    private GameObject[] characterList;
    private int index = 0;


    private void Start()
    {
        index = PlayerPrefs.GetInt("CharacterSelected");
        
        characterList = new GameObject[transform.childCount];

        //Fill array with character
        for (int i = 0; i < transform.childCount; i++)
        {
            characterList[i] = transform.GetChild(i).gameObject;
            characterList[i].transform.position = new Vector3(0, 0, 0);
        }
        //Visible off of all character
        foreach (GameObject go in characterList)
        {
            go.SetActive(false);
        }
        Debug.Log(index);
        //Visible true selected character
        if (characterList[index])
        {
            characterList[index].SetActive(true);
        }
    }

    public void CharacterLeftRight(bool left)
    {
        //Visible false old model
        characterList[index].SetActive(false);
        if (left == true)
        {
            index--;
            if (index < 0)
            {
                index = characterList.Length - 1;
            }
        }
        else
        {
            index++;
            if (index == characterList.Length)
            {
                index = 0;
            }
        }
        //Visible true new model
        characterList[index].SetActive(true);
    }

    public void ConfirmBtn()
    {
        PlayerPrefs.SetInt("CharacterSelected", index);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
}
