using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementPlayer : MonoBehaviour
{
    private static AchievementPlayer instance;

    public static AchievementPlayer GetInstance()
    {

        if (instance == null)
        {
            instance = FindObjectOfType(typeof(AchievementPlayer)) as AchievementPlayer;
        }
        return instance;
        
    }

    List<Observer> achievementObserver;                 //업적들
    Dictionary<string, int> achievePair;                //업적을 위한 짝 예 : (좀비, 0) (생존, 10) 
    List<Dictionary<string, object>> achievementData;   //업적 데이터
    //List<Dictionary<string, int>> orderofachievement;         //업적의 목록 순서

    //public delegate void AchievementNotification(string _achievCondition, int _conditionCount);
    //public event AchievementNotification achievementNotification;

    public int playerDeathCount;
    public int playerKillCount;
    public int playerSurvivalTime;

    public GameObject unlockAchievement;
    Text unlockText;

    private void Awake()
    {
        instance = this;
        playerDeathCount = PlayerPrefs.GetInt("PlayerDeath");
        playerKillCount = 0;
        playerSurvivalTime = 0;
        
        achievementObserver = new List<Observer>();

        achievementData = CSVReader.Read("Achievements");                               //업적 목록 받아오기

        unlockText = unlockAchievement.transform.GetChild(1).GetComponent<Text>();

        achievePair = new Dictionary<string, int>()
        {
            {"zombie",  0},
            {"survive", 0},
            {"death",   0}
        };

        for (int i = 0; i < achievementData.Count; i++)                                 // 생성
        {
            Observer achievements = new Observer();

            achievements.achieveCondition = achievementData[i]["AchievementCondition"].ToString(); //업적당 조건 및 횟수 할당
            achievements.achieveCount = (int)achievementData[i]["AchievementCount"];

            AddAchievement(achievements);                                                           //각 업적을 리스트에 할당

        }

        unlockAchievement.SetActive(false);
    }

    private void Update()
    {
        achievePair["zombie"] = playerKillCount;
        achievePair["survive"] = playerSurvivalTime;
        achievePair["death"] = playerDeathCount;

        for (int i = 0; i < achievementObserver.Count; i ++)
        {
            if (achievementObserver[i].achieveCount == achievePair[achievementObserver[i].achieveCondition])   //옵저버의 업적달성 횟수가 계속 업데이트 되는 옵저버의 조건의 횟수와 같으면
            {
                if (PlayerPrefs.GetInt(achievementData[i]["AchievementName"].ToString()) == 0)
                {
                    unlockText.text = achievementData[i]["AchievementName"].ToString();                            //할당
                    StartCoroutine(IPopAchievement(unlockAchievement));

                    PlayerPrefs.SetInt(achievementData[i]["AchievementName"].ToString(), 1);
                }

                //AchievementData.achievementList[i].transform.GetChild(2).gameObject.SetActive(false);

                //while (unlockAchievement.GetComponent<RectTransform>().localPosition.y < -420)
                //{
                //    Debug.Log("aa");
                //    //unlockAchievement.GetComponent<RectTransform>().localPosition = new Vector3(0, -700, 0);
                //    //unlockAchievement.transform.position new Vector3(0, 10, 0);
                //}

                //unlockAchievement.GetComponent<RectTransform>().localPosition = new Vector3(0, -700, 0);
                //StartCoroutine(IPopAchievement(unclockAchievement));
                //UnlockAchievement(achievementObserver[i]);
            }
        }

    }

    public void AddAchievement(Observer observer)
    {
        achievementObserver.Add(observer);
    }

    public void UnlockAchievement(Observer observer)
    {
        achievementObserver.Remove(observer);
    }

    IEnumerator IPopAchievement(GameObject gameObject)
    {
        gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
    }

    //IEnumerator IPopAchievement(GameObject gameObject)
    //{
    //    Vector3 rectPos = gameObject.GetComponent<RectTransform>().localPosition;
        

    //    while(rectPos.y < -420f)
    //    {
    //        rectPos += new Vector3(0, 10f, 0);
    //        yield return null;
    //    }

    //    gameObject.GetComponent<RectTransform>().localPosition = new Vector3(0, -700, 0);
    //}

}
