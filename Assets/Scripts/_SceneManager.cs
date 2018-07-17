using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class _SceneManager : MonoBehaviour {

    public void GoSceneName(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void GoNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void GoBackScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        Debug.Log("Back Scene clicked");
    }

    public void ExitLobby()
    {


        NetworkManager.singleton.StopClient();
        NetworkManager.singleton.StopHost();

        NetworkLobbyManager.singleton.StopClient();
        NetworkLobbyManager.singleton.StopServer();

        NetworkServer.DisconnectAll();
        //Network.Disconnect ();

        StartCoroutine(ExitDelay());

    }

    IEnumerator ExitDelay()
    {
        yield return new WaitForSeconds(0.1f);//attends un peu
        Destroy(NetworkLobbyManager.singleton.gameObject);

        yield return new WaitForSeconds(0.1f);//attends un peu

        SceneManager.LoadScene("03.SelectNbPlayer"); // SCENE SUIVANTE

    }

}
