using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayPauseScript : MonoBehaviour {

    public Button btnPlay;
    public Button btnPause;

    void Awake()
    {
        btnPlay.gameObject.SetActive(false);
    }
    void Start()
    {

        btnPlay = btnPlay.GetComponent<Button>();
        btnPause = btnPause.GetComponent<Button>();
        //Show bouton Play, disable Pause
        btnPause.onClick.AddListener(() => PlayPause(0));
        //Show bouton Pause, disable Play
        btnPlay.onClick.AddListener(() => PlayPause(1));
    }

    void PlayPause(int mode)
    {
        switch (mode)
        {
            case 0:
                btnPlay.gameObject.SetActive(true);
                btnPause.gameObject.SetActive(false);
                break;
            case 1:
                btnPlay.gameObject.SetActive(false);
                btnPause.gameObject.SetActive(true);
                break;
        }

    }
}
