using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShowBtn : MonoBehaviour {

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
}
