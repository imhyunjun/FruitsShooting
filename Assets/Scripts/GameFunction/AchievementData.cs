using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementData : MonoBehaviour
{
    public GameObject achievementPrefab;
    public List<GameObject> achievementList = new List<GameObject>();

    List<Dictionary<string, object>> achievementData;

    private void Awake()
    {
        achievementData = CSVReader.Read("Achievements");                               //업적 목록 받아오기
        
        for (int i = 0; i < achievementData.Count; i++)                                 // 생성
        {
            achievementList.Add(achievementPrefab);

            if (!PlayerPrefs.HasKey(achievementData[i]["AchievementName"].ToString()) || PlayerPrefs.GetInt(achievementData[i]["AchievementName"].ToString()) == 0)
            {

                achievementList[i].transform.GetChild(2).gameObject.SetActive(true);
                PlayerPrefs.SetInt(achievementData[i]["AchievementName"].ToString(), 0);
            }

            //if (PlayerPrefs.GetInt(achievementData[i]["AchievementName"].ToString()) == 0)
            //{
            //    achievementList[i].transform.GetChild(2).gameObject.SetActive(true);

            //    //PlayerPrefs.SetInt(achievementData[i]["AchievementName"].ToString(), 0);                //해금 안된 것은 0, 해결 된 건 1   
            //}

            else //if(PlayerPrefs.GetInt(achievementData[i]["AchievementName"].ToString()) == 1)
            {
                achievementList[i].transform.GetChild(2).gameObject.SetActive(false);
            }

            achievementList[i].transform.GetChild(0).GetComponent<Text>().text = achievementData[i]["AchievementName"].ToString();           //업적 이름 할당
            achievementList[i].transform.GetChild(1).GetComponent<Text>().text = achievementData[i]["AchievementDescription"].ToString();    //업적 설명 할당

            //achievementList[i].transform.GetChild(3).GetComponent<Text>().text = "#" + (i + 1);   //업적 번호 할당 오류가 생김 귀찬으니 나중에 추가

            Instantiate(achievementPrefab, this.transform);
        }
    }

    private void OnEnable()
    {
        for (int i = 0; i < achievementData.Count; i++)                                 // 생성
        {
            if (!PlayerPrefs.HasKey(achievementData[i]["AchievementName"].ToString()) || PlayerPrefs.GetInt(achievementData[i]["AchievementName"].ToString()) == 0)
            {
                
                achievementList[i].transform.GetChild(2).gameObject.SetActive(true);
                PlayerPrefs.SetInt(achievementData[i]["AchievementName"].ToString(), 0);
            }

            else 
            {
                achievementList[i].transform.GetChild(2).gameObject.SetActive(false);
            }

        }
    }

    //public void OnDisable()
    //{
    //    for (int i = 0; i < achievementList.Count; i++)
    //        Debug.Log(achievementList[i]);

    //    for (int i = 0; i < this.transform.childCount; i++)
    //    {
    //        Debug.Log("Asdfasdf" + i);

    //        Destroy(this.transform.GetChild(i));
    //        achievementList.RemoveAt(i);
    //    }

    //    for (int i = 0; i < achievementList.Count; i++)
    //        Debug.Log(achievementList[i]);
    //}

}
