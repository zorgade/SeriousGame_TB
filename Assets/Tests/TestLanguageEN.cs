using UnityEngine;
using System.Collections;
using NUnit.Framework;
using UnityEngine.TestTools;

public class TestLanguageEN : UITest {


    [UnityTest]
    public IEnumerator ENBtnFunctionCorrectly()
    {
        yield return LoadScene("00.ChooseLanguage");

        // Wait until object with given component appears in the scene
        yield return WaitFor(new ObjectAppeared<LocalizationManager>());

        // Wait until button with given name appears and simulate press event
        yield return Press("BtnEn");

        yield return WaitFor(new ObjectAppeared<GetIntro>());

        // Wait until Text component with given name appears and assert its value
        yield return AssertLabel("Panel/Lang", "en");

        yield return Press("SkipIntro");

        // Wait until object with given component disappears from the scene
        // yield return WaitFor(new ObjectDisappeared<_SceneManager>());
    }
}
