using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class _SceneManager : MonoBehaviour
{

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

    public void ExitLobby(GameObject NetworkManagerGameObject)
    {
        NetworkManagerGameObject.SetActive(false);
        Destroy(NetworkManagerGameObject);
        NetworkManager.singleton.StopHost();
        SceneManager.LoadScene("03.SelectNbPlayer"); // SCENE SUIVANTE

    }
}
