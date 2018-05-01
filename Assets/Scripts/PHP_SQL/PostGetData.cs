using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostGetData : MonoBehaviour {
    /*
     *     public string[] users;
    string usersDataString;
    private string pseudo = "Pseudo:";

    public Text txt;
    public Text userTxtUI;
    WWW www;
    string url = "http://localhost:8080/SeriousGame/";
    IEnumerator GetData(string pseudo)
    {
        WWW userData = new WWW(url + "UserData.php");
        yield return userData;
        string userDataString = userData.text;
        print(userDataString);
        users = userDataString.Split(';');
        txt.text = GetDataValue(users[1], pseudo);
        Debug.Log(txt.text);
    }

    IEnumerator GetUser(string pseudo)
    {
        WWW userData = new WWW(url + "UserData.php");
        yield return userData;
        string userDataString = userData.text;
        print("SELECT user" + userDataString);
        users = userDataString.Split(';');
        txt.text = GetDataValue(users[1], pseudo);
        Debug.Log("SELECT user" + txt.text);
    }

    string GetDataValue(string data, string index)
    {
        string value = data.Substring(data.IndexOf(index) + index.Length);
        if (value.Contains("|")) value = value.Remove(value.IndexOf("|"));
        return value;
    }
     */
}
