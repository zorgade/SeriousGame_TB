using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LaunchNextSceneTimer : MonoBehaviour {

    public float timer;
    public string sceneName;

    public void GoToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        Debug.Log("Play Ckicked");
    }

    public void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0.0f)
        {
            GoToScene(sceneName);
        }
    }
}
