using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetIntro : MonoBehaviour {

    public Button btnPlay;
    public Button btnPause;

    private void Awake()
    {
        btnPlay.gameObject.SetActive(false);
    }
    void Start()
    {

        btnPlay = btnPlay.GetComponent<Button>();
        btnPause = btnPause.GetComponent<Button>();
        btnPause.onClick.AddListener(() => PlayPause(0));
        btnPlay.onClick.AddListener(() => PlayPause(1));
    }

    private void PlayPause(int mode)
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
