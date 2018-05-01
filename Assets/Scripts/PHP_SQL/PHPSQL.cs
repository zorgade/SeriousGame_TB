using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PHPSQL : MonoBehaviour
{
    /*
    public string[] items;
    string itemsDataString;
    public Text txt;
    private static string url = "http://localhost:8080/SeriousGame/UserData.php";
    WWW www;

     /*void Start()
    {
        StartCoroutine(GetData());
    }*//*
    IEnumerator Start()
    {
        using (WWW www = new WWW(url))
        {
            yield return www;
            itemsDataString = www.text;
            print(itemsDataString);
            items = itemsDataString.Split(';');
            print(GetDataValue(items[0], "Name:"));
            txt.text = GetDataValue(items[0], "Name:");
        }
        //WWW itemsData = new WWW("");
        //yield return itemsData;
        //itemsDataString = itemsData.text;
        
    }

    string GetDataValue(string data, string index)
    {
        string value = data.Substring(data.IndexOf(index) + index.Length);
        if (value.Contains("|")) value = value.Remove(value.IndexOf("|"));
        return value;
    }*/
}