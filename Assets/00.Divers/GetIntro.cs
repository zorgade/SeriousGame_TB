using LitJson;
using SimpleFirebaseUnity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class User
{
    public string pseudo;
    public string score;
}

public class Intro
{
    public string title;
    public string texte;
}


public class GetIntro : MonoBehaviour
{
    public string lang = "fr";
    public Button btnFR;
    public Button btnEN;
    public Button btnDE;
    public Button btnIT;

    private static string auth = "?=w68VJkOD9YzM2x9zqsBv7rQOoskL11KwTSPkrIHn";
    public Text txt;
    WWW www;
    string url; // = "https://seriousgametb.firebaseio.com/" + "Intro/Texte/" + lang + ".json?auth=w68VJkOD9YzM2x9zqsBv7rQOoskL11KwTSPkrIHn";

    /* IEnumerator Start()
     {
         FirebaseRestClient rClient = new FirebaseRestClient();
         rClient.endPoint = url;
         Debug.Log("RestClinet created");

         string strResponse = string.Empty;
         strResponse = rClient.makeRequest();
         Debug.Log(strResponse);
         txt.text = strResponse;

         /*Firebase firebase = Firebase.CreateNew("seriousgametb.firebaseio.com"+auth);
         //firebase.Child("score").SetValue("2");


         Firebase lastUpdate = firebase.Child("Users");

             lastUpdate.Child("pseudo").SetValue("taay");
         lastUpdate.GetValue(FirebaseParam.Empty.OrderByKey().LimitToFirst(1));
         lastUpdate.GetValue("score=10");

         www = new WWW(url);
         yield return www;
         if (www.error == null)
         {
             Processjson(www.text);
         }
         else
         {
             Debug.Log("ERROR: " + www.error);
         }
     }*/
    private void Start()
    {
        

    }
    void Update()
    {
        url = "https://seriousgametb.firebaseio.com/" + "Intro/Texte/" + lang + ".json?auth=w68VJkOD9YzM2x9zqsBv7rQOoskL11KwTSPkrIHn";
        FirebaseRestClient rClient = new FirebaseRestClient();
        rClient.endPoint = url;
        Debug.Log("RestClinet created");

        string strResponse = string.Empty;
        strResponse = rClient.makeRequest();
        Debug.Log(strResponse);
        txt.text = strResponse;
        Debug.Log("LANG: "+lang);

        btnFR = btnFR.GetComponent<Button>();
        btnFR.onClick.AddListener(() => ChangeLanguage("fr"));

        btnEN = btnEN.GetComponent<Button>();
        btnEN.onClick.AddListener(() => ChangeLanguage("en"));

        btnDE = btnDE.GetComponent<Button>();
        btnDE.onClick.AddListener(() => ChangeLanguage("de"));

        btnIT = btnIT.GetComponent<Button>();
        btnIT.onClick.AddListener(() => ChangeLanguage("it"));
    }
    public void ChangeLanguage(string lang)
    {
        this.lang = lang;

    }
    public void Processjson(string jsonString)
    {
        JsonData jsonvale = JsonMapper.ToObject(jsonString);
        /*User users;
        users = new User();
        users.pseudo = jsonvale["pseudo"].ToString();
        users.score= jsonvale["score"].ToString();
        Debug.Log(users.pseudo+" "+users.score);
        textMesh.text = users.pseudo;*/

        Intro intros;
        intros = new Intro();
        intros.title = jsonvale[lang].ToString();
       // intros.texte = jsonvale[lang].ToString();
        Debug.Log(intros.title);
        //txt.text = intros.title;
        Update();

    }
    // Use this for initialization
    /*void Start()
    {
        textMesh.text = "";
        Firebase firebase = Firebase.CreateNew("seriousgametb.firebaseio.com");
        firebase.Child("{\"name\": \"taylan\", \"message\": \"Title...\"}", true);
        //firebase.Child("score").SetValue("2");
        Firebase lastUpdate = firebase.Child("Users");

        //lastUpdate.Delete();
        lastUpdate.Child("pseudo").SetValue("tay");
        lastUpdate.GetValue(FirebaseParam.Empty.OrderByKey().LimitToFirst(1));
        firebase.Child("scores", true).GetValue(FirebaseParam.Empty.OrderByChild("rating").LimitToFirst(1));
        lastUpdate.GetValue("score=10");
        string getURL = "https://seriousgametb.firebaseio.com/";
        UnityWebRequest www = UnityWebRequest.Get(getURL + "-LAqUVOS5jYycwQptMUj.json");
        Debug.Log(www.ToString());
    }*/
}
