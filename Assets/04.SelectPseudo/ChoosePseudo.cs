using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChoosePseudo : MonoBehaviour
{

    public InputField[] pseudo = new InputField[4];
    //Label pseudo
    public Text[] label = new Text[4];
    public Text pseudoTitle;
    public Button nextBtn;
    public static int nbrePlayers;
    public static string[] pseudoName;
    public static List<Player> players = new List<Player>();
    private static bool wwwResult = false;
    string url = "http://163.172.150.132/SeriousGame/PostUser.php";
    int score = -1;
    int position = 0;
    bool played;

    // initialization-
    void Start()
    {
        nextBtn.GetComponent<Button>();
        //nextBtn.gameObject.SetActive(true);
        nextBtn.gameObject.SetActive(true);
        pseudoTitle.GetComponent<Text>();
        pseudoTitle.gameObject.SetActive(true);
        nbrePlayers = SelectNbrePlayer.nbrePlayer;

        Debug.Log(nbrePlayers);
        //Recuperation des champs
        for (int i = 0; i < pseudo.Length; i++)
        {
            pseudo[i].GetComponent<InputField>();
            label[i].GetComponent<Text>();
        }
        //Activation-desactivation des champs selon le nbre d'utilisateur.
        EnableInputField(nbrePlayers);
        pseudoName = new string[nbrePlayers];
    }
    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < nbrePlayers; i++)
        {
            //string test = pseudo[i].text;
            if (string.IsNullOrEmpty(pseudo[i].text) || pseudo[i].text.Equals(" "))
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
        Debug.Log("Value " + value);
        //Desactive les InputField
        DisableInputField(false);

        //Active les InputField - selon value
        for (int i = 0; i < value; i++)
        {
            pseudo[i].gameObject.SetActive(true);
            label[i].gameObject.SetActive(true);
        }


    }
    //Desactive les InputFiled
    private void DisableInputField(bool value)
    {
        for (int i = 0; i < pseudo.Length; i++)
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
        for (int i = 0; i < nbrePlayers; i++)
        {
            Debug.Log(i);
            // Create a form object for sending high score data to the server
            WWWForm form = new WWWForm();
            // The name of the player submitting the scores

            pseudoName[i] = pseudo[i].text.ToString();
            form.AddField("pseudo", pseudoName[i]);
            // The score
            form.AddField("score", score);
            form.AddField("position", position);
            played = false;
            Player player = new Player(pseudoName[i], score, position, played);
            players.Add(player);
            Debug.Log(pseudoName[i] + score + position + played);


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
            SceneManager.LoadScene("05A.LaunchDice");
        }
    }
}
