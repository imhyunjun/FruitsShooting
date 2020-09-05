using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainBtn : MonoBehaviour
{
    public GameObject achievementPanel;

    public void StartBtn()
    {
        if (!PlayerPrefs.HasKey("VeryFirstPlay"))       //최초 플레이면 프롤로그
        {
            PlayerPrefs.SetInt("VeryFirstPlay", 1);     //최초 플레이가 아님을 설정  
            SceneManager.LoadScene("Prologue");
        }
        else                                            //최초 플레이가 아니면 게임 화면
        {   
            SceneManager.LoadScene("PlayGame");
        }
    }

    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void DeleteAllRecords()                      //모든 기록 삭제
    {
        PlayerPrefs.DeleteAll();
    }

    public void OpenAchievement()
    {
        achievementPanel.SetActive(true);
    }

    public void CloseAchievement()
    {
        achievementPanel.SetActive(false);
    }


}
