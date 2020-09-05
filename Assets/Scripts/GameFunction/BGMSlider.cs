using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGMSlider : MonoBehaviour
{
    Slider sliderValue;
    public static float soundVolume;                //bgm 자체에서 접근 가능하도록 staitc

    private void Awake()
    {
        sliderValue = gameObject.GetComponent<Slider>();
    }


    private void OnEnable()
    {
        sliderValue.value = PlayerPrefs.GetFloat("backvol");        //활성화 시 저장된 볼륨 값 얻어오기
    }

    private void Update()
    {
        soundVolume = sliderValue.value;                            //볼륨값은 슬라이더 바의 값
        //PlayerPrefs.SetFloat("backvol", sliderValue.value);
    }

    private void OnDisable()                                        //비활성화 될때 볼륨값 저장
    {
        PlayerPrefs.SetFloat("backvol", soundVolume);
    }
}
