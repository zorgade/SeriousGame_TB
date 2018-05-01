using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NewUser : MonoBehaviour {

    /*string url = "http://localhost:8080/SeriousGame/PostUser.php";
    string playName = "Player 1";
    int score = -1;
    int position = 0;
    // Use this for initialization
    IEnumerator Start()
    {
        // Create a form object for sending high score data to the server
        WWWForm form = new WWWForm();
        // The name of the player submitting the scores
        form.AddField("pseudo", playName);
        // The score
        form.AddField("score", score);
        form.AddField("position", position);


        // Create a download object
        var download = UnityWebRequest.Post(url, form);

        // Wait until the download is done
        yield return download.SendWebRequest();

        if (download.isNetworkError || download.isHttpError)
        {
            print("Error downloading: " + download.error);
        }
        else
        {
            // show the highscores
            Debug.Log(download.downloadHandler.text);
        }
    }*/
}
