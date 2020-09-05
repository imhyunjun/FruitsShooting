using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptButton : MonoBehaviour
{
   public void OnClickSkipButton()
    {
        SceneManager.LoadScene("PlayGame");
    }

    public void OnClickPrologueButton()
    {
        SceneManager.LoadScene("Prologue");
    }

    public void OnClickCreditButton()
    {
        SceneManager.LoadScene("Credit");
    }
}
