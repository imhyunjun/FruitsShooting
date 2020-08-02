using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainBtn : MonoBehaviour
{
    public void StartBtn()
    {
        SceneManager.LoadScene("PlayGame");
    }

    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
}
