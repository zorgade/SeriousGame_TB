using UnityEngine;
using System.Collections;
using NUnit.Framework;
using UnityEngine.TestTools;

public class TestLanguage : UITest {

    [UnityTest]
    public IEnumerator Test_FRBtnFunctionGiveFrenchLang()
    {
        yield return LoadScene("00.ChooseLanguage");

        // Wait until object with given component appears in the scene
        yield return WaitFor(new ObjectAppeared<LocalizationManager>());

        // Wait until button with given name appears and simulate press event
        yield return Press("BtnFr");

        yield return WaitFor(new ObjectAppeared<PlayPauseScript>());

        // Wait until Text component with given name appears and assert its value
        yield return AssertLabel("Panel/Lang", "fr");

    }
}
