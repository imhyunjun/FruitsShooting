using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TimeScore : MonoBehaviour
{
    public Text score;

    protected Text[] rankingsText;                  //랭킹 6개
    protected Text[] rankingsDate;                  //랭킹 날짜
    protected int countRanking;                     //6등까지 기억

    public GameObject rankingPanel;

    [SerializeField]
    protected double time;

    protected Dictionary<string, string> rankedDateDic;   //랭크 기록된 날짜

    private void Awake()
    {
        time = 0;
        score.text = time.ToString();

        rankedDateDic = new Dictionary<string, string>();

        countRanking = 6;
        rankingsText = new Text[countRanking];
        rankingsDate = new Text[countRanking];

         for (int i = 0; i < countRanking; i++)       //점수 받는 배열 초기화
        {
            rankingsText[i] = rankingPanel.transform.GetChild(i).GetChild(1).gameObject.GetComponent<Text>();
            rankingsDate[i] = rankingPanel.transform.GetChild(i).GetChild(2).gameObject.GetComponent<Text>();

            rankingsText[i].text = 0.ToString();
            rankingsDate[i].text = 1.ToString();
        }
    }

    private void Start()                //초기화
    {
        for (int i = 0; i < countRanking; i++)       //점수 받는 배열 초기화
        {
            if (PlayerPrefs.HasKey(i.ToString()))
            {
                rankingsText[i].text = PlayerPrefs.GetString(i.ToString());
                rankingsDate[i].text = PlayerPrefs.GetString(rankingsText[i].text.ToString());
            }
        }

    }

    void Update()
    {
        time = Math.Round((Time.timeSinceLevelLoad), 1);                               //씬이 로드 된 이후부터 시간을 소수 둘째 자리로 반올림
        score.text = time.ToString();
        AchievementPlayer.GetInstance().playerSurvivalTime = Mathf.FloorToInt((float)time);
    }

    public void MakeDescendingArray(Text[] _oldNumbers, double _newNumber)                       //배열안에 있는 수와 새로운 수로 배열을 하나 만든 후 내림차순 -> 위에서부터 할당
    {
        double[] tempArray = new double[_oldNumbers.Length + 1];                      //새로운 수로 기존 배열보다 원소가 하나 많은 배열 생성
        for (int i = 0; i < _oldNumbers.Length; i++)                             //기존 배열 int로 형변후 대입
        {
            Double.TryParse(_oldNumbers[i].text, out double j);
            tempArray[i] = j;
        }

        tempArray[_oldNumbers.Length] = _newNumber;                             //마지막 원소는 새로운 숫자
        Array.Sort(tempArray);                                                  //오름차순으로 정렬
        Array.Reverse(tempArray);                                               //내림차순으로 정렬

        for (int i = 0; i < _oldNumbers.Length; i++)                             //기존의 배열에 하나씩 위에서부터 할당
        {
            _oldNumbers[i].text = tempArray[i].ToString();
        }
    }

}
