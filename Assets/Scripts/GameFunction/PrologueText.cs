using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrologueText : MonoBehaviour
{
    int dialIndex;                //텍스트 번호 
    Text dialText;                // 대화텍스트
    string[] dialSentence;        //문장 하나씩 받아올 것
    int sentenceIndex;            //문장 번호
    List<Dictionary<string, object>> prologueData;

    IEnumerator Start()
    {
        prologueData = CSVReader.Read("Story");
        dialIndex = 0;
        sentenceIndex = 0;

        dialText = gameObject.GetComponent<Text>();
        dialText.text = "";

        dialSentence = new string[prologueData.Count];      //대화 길이 만큼 초기화

        for(int i = 0; i < prologueData.Count; i ++)
        {
            dialSentence[i] = prologueData[i]["Story"].ToString();
        }

        yield return new WaitForSeconds(1f);                //1초 후 처음 대화창 출력
        StartCoroutine(IPrintByALetter(dialText));
        
    }

    IEnumerator IPrintByALetter(Text _text)
    {
        while (sentenceIndex < prologueData.Count)
        {
            dialIndex = 0;
            gameObject.GetComponent<AudioSource>().Play();

            while (dialIndex < dialSentence[sentenceIndex].Length)
            {
                _text.text += dialSentence[sentenceIndex][dialIndex];   //한줄씩 출력
                dialIndex++;
                yield return new WaitForSeconds(0.1f);              //1초마다 글자 보이기
            }
            _text.text += System.Environment.NewLine;               //줄바꿈
            gameObject.GetComponent<AudioSource>().Stop();
            sentenceIndex++;
            yield return new WaitUntil(()=> Input.GetMouseButton(0));       //마우스 클릭될때까지 대기
        }
    }

}
