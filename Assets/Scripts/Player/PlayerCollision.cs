using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollision : TimeScore
{
    
    public GameObject buttonPanel;

    private void OnTriggerEnter2D(Collider2D _collision)
    {
        //좀비와 부딪히면
        if (_collision.transform.CompareTag("Zombie"))  
        {
            PlayerPrefs.SetInt("PlayerDeath", AchievementPlayer.GetInstance().playerDeathCount + 1);            //지금까지 죽은 횟수 저장
            AchievementPlayer.GetInstance().playerSurvivalTime = Mathf.FloorToInt((float)time);                   //게임이 끝날때 시간 버림해서 최대 생존 시간
            PlayerPrefs.SetInt("PlayerSurvivalTime", AchievementPlayer.GetInstance().playerSurvivalTime);

            Time.timeScale = 0;                         //게임 끝
            buttonPanel.SetActive(true);                //버튼 panel 활성화

            rankedDateDic.Add(time.ToString(), System.DateTime.Now.ToString());
           
            MakeDescendingArray(rankingsText, time);          //기존 랭킹과, 새로운 기록 비교
            rankingPanel.SetActive(true);
            for (int i = 0; i < rankingsText.Length; i++)
            {
                PlayerPrefs.SetString(i.ToString(), rankingsText[i].text);               //시간을 점수로 저장
                if (rankedDateDic.ContainsKey(rankingsText[i].text))
                {
                    PlayerPrefs.SetString(rankingsText[i].text, rankedDateDic[rankingsText[i].text]);
                    rankingsText[i].text = PlayerPrefs.GetString(i.ToString());         //점수판에 반영
                    rankingsDate[i].text = PlayerPrefs.GetString(rankingsText[i].text);      //그에 따른 날짜도 반영
                }
                
            }
        }
    }

   
}
