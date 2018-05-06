using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChoosePseudo : MonoBehaviour {

    public InputField[] pseudo = new InputField[4];
    //Label pseudo
    public Text[] label = new Text[4];
    public Text pseudoTitle;
    public Button nextBtn;

    public static int nbrePlayer;
    public static string[] pseudoName;


    private static bool wwwResult = false;
    string url = "http://localhost:8080/SeriousGame/PostUser.php";
    int score = -1;
    int position = 0;

    // initialization-
    void Start () {
        nextBtn.gameObject.SetActive(false);
        nbrePlayer = SelectNbrePlayer.nbrePlayer;
        pseudoTitle.GetComponent<Text>();
        pseudoTitle.gameObject.SetActive(true);
        Debug.Log(nbrePlayer);
        //Recuperation des champs
        for(int i=0; i< pseudo.Length; i++)
        {
            pseudo[i].GetComponent<InputField>();
            label[i].GetComponent<Text>();
        }
        //Activation-desactivation des champs selon le nbre d'utilisateur.
        EnableInputField(nbrePlayer);
        pseudoName = new string[nbrePlayer];
        //StartCoroutine(Test(test));
    }
        // Update is called once per frame
        void Update()
    {
        for (int i = 0; i < nbrePlayer; i++)
        {

                string test = pseudo[i].text.ToString();
                if (string.IsNullOrEmpty(test) || test == " ")
                {
                nextBtn.gameObject.SetActive(false);
                pseudoTitle.gameObject.SetActive(true);


            }
            else
            {
                nextBtn.gameObject.SetActive(true);
                pseudoTitle.gameObject.SetActive(false);

            }

        }
    }

    //Active les InputFiled
    private void EnableInputField(int value)
    {
        Debug.Log("Value "+value);
        //Desactive les InputField
        DisableInputField(false);

        //Active les IP - selon value
        for(int i = 0; i < value; i++)
        {
            pseudo[i].gameObject.SetActive(true);
            label[i].gameObject.SetActive(true);
        }


    }
    //Desactive les InputFiled
    private void DisableInputField(bool value)
    {
            for(int i = 0; i < pseudo.Length; i++)
        {
            pseudo[i].gameObject.SetActive(false);
            label[i].gameObject.SetActive(false);
        }
    }

    public void PostPseudo()
    {
        StartCoroutine(SavePseudoName());
        
    }
    IEnumerator SavePseudoName()
    {            
            for (int i = 0; i < nbrePlayer; i++)
        {
            // Create a form object for sending high score data to the server
            WWWForm form = new WWWForm();
            // The name of the player submitting the scores

            pseudoName[i] = pseudo[i].text.ToString();
            form.AddField("pseudo", pseudoName[i]);
            // The score
            form.AddField("score", score);
            form.AddField("position", position);
            Player[] player = new Player[nbrePlayer];
            player[i] = new Player(pseudoName[i], score, position);

            Debug.Log(player[i].Pseudo.ToString());


            // Create a download object
            var download = UnityWebRequest.Post(url, form);

            // Wait until the download is done
            yield return download.SendWebRequest();

            if (download.isNetworkError || download.isHttpError)
            {
                print("Error downloading: " + download.error);
                wwwResult = false;
            }
            else
            { 
                // Load next screen
                wwwResult = true;
                Debug.Log(download.downloadHandler.text);
            }
        }
            //If post success load next screen
        if (wwwResult)
        {
            SceneManager.LoadScene("05.LaunchDice");
        }
    }
}
