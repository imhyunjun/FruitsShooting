using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public Text dialText;
    public GameObject player;                   //플레이어

    int dialCount;                              //대화 갯수
    int dialOrder;                              //대화 순번

    List<Dictionary<string, object>> dialData; 

    void Awake()
    {
        dialOrder = 0;
        Time.timeScale = 0;
        Debug.Log(Time.timeScale);
        dialData = CSVReader.Read("Tutorial");                  //csv파일에서 대화창 불러오기
        dialCount = dialData.Count;
        SetDial(dialOrder, "System");

    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return) && Time.timeScale == 0)                    //엔터를 치면 및 화면 정지할때만
        {
            dialOrder++;
            switch (dialOrder)
            {
                case 3:
                    StartCoroutine(ActWhileTutorial(false, 5));
                    break;
                case 7:
                    StartCoroutine(ActWhileTutorial(true, 10));
                    break;
                case 10:
                    Debug.Log("타이틀 화면으로");
                    SceneManager.LoadScene("Main");
                    dialOrder = 0;
                    break;
                default:
                    break;
            }
            SetDial(dialOrder, "System");
        }
 
    }

    //시간 정지, 해제 함수
    void TimePause()                                            
    {
        if (Time.timeScale == 0) Time.timeScale = 1;
        else Time.timeScale = 0;
    }

    //다음 대화
    void SetDial(int _index, string _header)
    {
        dialText.text = dialData[_index][_header].ToString();
    }

    IEnumerator ActWhileTutorial(bool _isPlayerActing, int _time)
    {
        while(Time.time < _time)                                        //5초정도만 움직이게
        {
            Time.timeScale = 1;
            player.GetComponent<PlayerShooting>().enabled = _isPlayerActing;

            yield return null;
        }
        TimePause();
        player.GetComponent<PlayerShooting>().enabled = true;                   //다시 원래대로
        dialOrder++;
        SetDial(dialOrder, "System");
    }
}
