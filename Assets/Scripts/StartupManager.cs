using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartupManager : MonoBehaviour {

    // Use this for initialization
    private IEnumerator Start()
    {
        //Attend que Localizationmanger, fichier Json des langues, est chargé -> isReady
        while (!LocalizationManager.instance.GetIsReady())
        {
            yield return null;
        }

        SceneManager.LoadScene("01.Intro");
    }
}
