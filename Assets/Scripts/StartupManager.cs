using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartupManager : MonoBehaviour {

    // Use this for initialization
    private IEnumerator Start()
    {
        //Wait for Localizationmanger isReady
        while (!LocalizationManager.instance.GetIsReady())
        {
            yield return null;
        }

        SceneManager.LoadScene("01.Intro");
    }
}
