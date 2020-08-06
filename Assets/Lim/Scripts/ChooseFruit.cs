using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseFruit : MonoBehaviour
{
    Image[] selectFruit;                    //쏠 과일 고르는 이미지 배열 
    Color[] tempColor;                      //임시 색 배열
    Color selectedBeforeColor;                   //전에 선택한 번호
    Image selectedNow;                      //현재 선택되어 있는 과일
    int selectedIndex;                     //현재 선택되어 있는 번호

    int countFruit;                         //쏠 수 있는 과일 개수(현재는 두개 바나나, 딸기)

    KeyCode[] keyCodes = {                  //과일 바꿀때 쓰는 코드( 위에1, 2)
            KeyCode.Alpha1,
            KeyCode.Alpha2
        };

    protected void Start()
    {
        countFruit = transform.childCount;
        selectFruit = new Image[countFruit];
        tempColor = new Color[countFruit];
        
        for(int i = 0; i < countFruit; i++)         //배열 초기화 및 투명도 설정
        {
            selectFruit[i] = transform.GetChild(i).GetComponent<Image>();
            tempColor[i] = selectFruit[i].color;
            if(i == 0)
            {
                tempColor[i].a = 1;
            }
            else
            {
                tempColor[i].a = 0.5f;
            }
            selectFruit[i].color = tempColor[i];
        }
        selectedIndex = 0;
        selectedNow = selectFruit[selectedIndex];
        selectedBeforeColor = selectFruit[0].color;  
    }

    private void Update()
    {
        ChangeFruit(1);
        ChangeFruit(2);
    }

    //과일 선택( 1- 9) 까지만
   void ChangeFruit(int _i)
   { 
       if(Input.GetKeyDown(keyCodes[_i -1]))                       
       {
           selectedBeforeColor = selectFruit[_i - 1].color;
           selectFruit[_i - 1].color = selectedNow.color;                      //예) _i = 2 2번이 눌렸다. 배열 1번에 현재 선택되있는(배열0번)의 색을 대입
           selectFruit[selectedIndex].color = selectedBeforeColor;             //그 전에 선택된(배열 0번)그림에 원래 배열(1번의) 색을 대입
                                                                       
           selectedIndex = _i - 1;                                             //현재 인덱스를 1로 지정
           selectedNow = selectFruit[selectedIndex];                           //현재 선택된 이미지를 배열1 로 지정
       }
   }
}
