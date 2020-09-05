using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseUI;
    private bool paused = false;

    void Start()
    {
        PauseUI.SetActive(false);
        StartCoroutine("PausedOut");
    }

    void Update()
    {
        if (Input.GetButtonDown("Pause")) //게임세팅 인풋 19번(esc)에 퍼즈 추가함
        {
            paused = !paused;
        }

    }

    void FixedUpdate()
    {

        if (paused) //일시정지
        {
            PauseUI.SetActive(true);
            Time.timeScale = 0;
        }
    }

    IEnumerator PausedOut()
    {
        if (!paused)
        {
            PauseUI.SetActive(false);
            Time.timeScale = 1f;
            yield return null;
        }
    }

    public void Resume() //계속하기
    {
        paused = !paused;
        Time.timeScale = 1f;
        PauseUI.SetActive(paused);
    }


    public void OnClickMainButton()
    {
        SceneManager.LoadScene("Main");
    }
}