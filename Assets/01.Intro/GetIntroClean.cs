using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetIntroClean : MonoBehaviour {

    public string lang = "fr";
   /* public Button btnFR;
    public Button btnEN;
    public Button btnDE;
    public Button btnIT;*/

    public string[] users;
    string usersDataString;
    private string pseudo = "Pseudo:";

    public Text txt;
    public Text userTxtUI;
    WWW www;
    string url = "http://localhost:8080/SeriousGame/";

    public Button btnPlay;
    public Button btnPause;

    private void Awake()
    {
        btnPlay.gameObject.SetActive(false);
    }
    void Start()
    {

        btnPlay = btnPlay.GetComponent<Button>();
        btnPause = btnPause.GetComponent<Button>();
        btnPause.onClick.AddListener(() => PlayPause(0));
        btnPlay.onClick.AddListener(() => PlayPause(1));


        //Initialise lang button
        /*btnFR = btnFR.GetComponent<Button>();
        btnFR.onClick.AddListener(() => ChangeLanguage("Pseudo:"));

        btnEN = btnEN.GetComponent<Button>();
        btnEN.onClick.AddListener(() => ChangeLanguage("Score:"));

        btnDE = btnDE.GetComponent<Button>();
        btnDE.onClick.AddListener(() => ChangeLanguage("position:"));

        btnIT = btnIT.GetComponent<Button>();
        btnIT.onClick.AddListener(() => ChangeLanguage("it"));*/
        StartCoroutine(GetData(pseudo));
        StartCoroutine(GetUser(pseudo));





    }

    private void PlayPause(int mode)
    {
        switch (mode)
        {
            case 0:
                btnPlay.gameObject.SetActive(true);
                btnPause.gameObject.SetActive(false);
                break;
            case 1:
                btnPlay.gameObject.SetActive(false);
                btnPause.gameObject.SetActive(true);
                break;
        }

    }

    IEnumerator GetData(string pseudo)
    {
        WWW userData = new WWW(url+"UserData.php");
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
        Debug.Log("SELECT user"+txt.text);
    }

    string GetDataValue(string data, string index)
    {
        string value = data.Substring(data.IndexOf(index) + index.Length);
        if (value.Contains("|")) value = value.Remove(value.IndexOf("|"));
        return value;
    }

    public void ChangeLanguage(string lang)
    {
        this.lang = lang;
    }
}
