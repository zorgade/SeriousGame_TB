using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LaunchScene : MonoBehaviour {

    public float timer = 10f;
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
