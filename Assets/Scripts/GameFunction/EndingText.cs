using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingText : MonoBehaviour
{

    //현준님 감사합니다...~~!!!!!!

    int dialIndex;                //텍스트 번호 
    Text dialText;                // 대화텍스트
    string[] dialSentence;        //문장 하나씩 받아올 것
    int sentenceIndex;            //문장 번호
    List<Dictionary<string, object>> EndingData;

    IEnumerator Start()
    {
        EndingData = CSVReader.Read("Ending");
        dialIndex = 0;
        sentenceIndex = 0;

        dialText = gameObject.GetComponent<Text>();
        dialText.text = "";

        dialSentence = new string[EndingData.Count];      //대화 길이 만큼 초기화

        for (int i = 0; i < EndingData.Count; i++)
        {
            dialSentence[i] = EndingData[i]["Ending"].ToString();
        }

        yield return new WaitForSeconds(1f);                //1초 후 처음 대화창 출력
        StartCoroutine(IPrintByALetter(dialText));

    }

    IEnumerator IPrintByALetter(Text _text)
    {
        while (sentenceIndex < EndingData.Count)
        {
            dialIndex = 0;
            while (dialIndex < dialSentence[sentenceIndex].Length)
            {
                _text.text += dialSentence[sentenceIndex][dialIndex];   //한줄씩 출력
                dialIndex++;
                yield return new WaitForSeconds(0.1f);              //1초마다 글자 보이기
            }
            _text.text += System.Environment.NewLine;               //줄바꿈

            sentenceIndex++;
            yield return new WaitUntil(() => Input.GetMouseButton(0));       //마우스 클릭될때까지 대기
        }
    }

}
