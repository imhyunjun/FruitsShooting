using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainBtns : MonoBehaviour
{
    public void StartBtn()//버튼을 누르고 시간차를 주기위해
    {
        Invoke("startgame", 0.3f);
    }

    private void startgame()//플레이게임씬으로
    {
        SceneManager.LoadScene("PlayGame");
    }

    public void TutorialBtn()
    {
        Invoke("tutorial", 0.3f);
    }

    private void tutorial()//튜토리얼씬으로
    {
        SceneManager.LoadScene("Tutorial");
    }
}
