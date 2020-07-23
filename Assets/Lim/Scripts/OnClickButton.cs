using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnClickButton : MonoBehaviour
{
    // 새 게임 버튼
    public void OnClickNewGameButton()         
    {
        SceneManager.LoadScene("PlayGame");     //게임 씬 새로 로드
        Time.timeScale = 1;                     //정지 풀기
    }
}
