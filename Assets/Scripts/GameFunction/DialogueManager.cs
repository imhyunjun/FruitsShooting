using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public Text dialText;
    public GameObject player;                   //플레이어
    public 

    int dialCount;                              //대화 갯수
    int dialOrder;                              //대화 순번

    float enterCurrentTime;                          //현재 시간
    float enterLastTime;                             //마지막으로 엔터를 친 시간
    float enterDelay;                           //엔터 딜레이

    List<Dictionary<string, object>> dialData; 

    void Awake()
    {
        enterDelay = 1f;
        enterCurrentTime = 0f;
        enterLastTime = 0f;

        dialOrder = 0;
        Time.timeScale = 0;
        dialData = CSVReader.Read("Tutorial");                  //csv파일에서 대화창 불러오기
        dialCount = dialData.Count;
        SetDial(dialOrder, "System");

    }

    void Update()
    {
        enterCurrentTime += 0.02f;
        Debug.Log(enterCurrentTime);
        if(Input.GetKeyDown(KeyCode.Return) && Time.timeScale == 0 && (enterCurrentTime - enterLastTime) > enterDelay )                    //엔터를 치면 및 화면 정지할때만
        {
            dialOrder++;
            enterLastTime = enterCurrentTime;
            switch (dialOrder)
            {
                case 3:
                    StartCoroutine(ActWhileTutorial(false, 5));                         //아직 슈팅 불가능
                    break;
                case 8:
                    StartCoroutine(ActWhileTutorial(true, 5));                         //슈팅 가능
                    break;
                case 10:
                    SceneManager.LoadScene("Main");
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
        float currentTime = Time.time;

        while(Time.time < currentTime + _time)                                                    //5초정도만 움직이게
        {
            Time.timeScale = 1;
            player.GetComponent<PlayerShooting>().enabled = _isPlayerActing;        //슈팅 가능인지

            yield return null;
        }
        TimePause();
        player.GetComponent<PlayerShooting>().enabled = true;                       //다시 원래대로
        dialOrder++;
        SetDial(dialOrder, "System");
    }
}
