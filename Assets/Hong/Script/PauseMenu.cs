using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseUI;
    private bool paused = false;

    void Start()
    {
        PauseUI.SetActive(false);
    }

    void Update()
    {
        if (Input.GetButtonDown("Pause")) //게임세팅 인풋 19번(esc)에 퍼즈 추가함
        {
            paused = !paused;
        }
        if (paused) //일시정지
        {
            PauseUI.SetActive(true);
            Time.timeScale = 0;
        }

        if (!paused)  //일시정지 해제
        {
            PauseUI.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void Resume() //계속하기
    {
        paused = !paused;
    }

    
}
