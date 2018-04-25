using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour {

    public string sceneName;
    public Button btn;
    static float timer = 5.0f;

    void Start()
    {
        btn.gameObject.SetActive(false);
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0.0f)
        {
            timerEnded();
        }
    }

    public void timerEnded()
    {
        btn.gameObject.SetActive(true);
    }

    public void ChangeSc(string sceneName)
    {
      
            SceneManager.LoadScene(sceneName);
        
    }


}
