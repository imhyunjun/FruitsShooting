using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimeScore : MonoBehaviour
{
    Text scoreText;
    int time;

    void Start()                //초기화
    {
        scoreText = gameObject.GetComponent<Text>();
        time = 0;
        scoreText.text = "Score : " + time;
    }

   
    void Update()
    {
        time = Mathf.RoundToInt(Time.timeSinceLevelLoad);       //씬이 로드 된 이후부터 시간을 정수로 반올림
        scoreText.text = "Score : " + time;
        
    }
}
