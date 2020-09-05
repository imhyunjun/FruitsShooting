using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGM : MonoBehaviour
{
    //public Slider backVolume; //슬라이더 값 가져오기
    public AudioSource audios; //조절할 소스

    //private float backVol = 1f; //껐다켜도 값을 유지하기위해 추가

    public static BGM Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        BGMSlider.soundVolume = PlayerPrefs.GetFloat("backvol");            //슬라이더 자체가 처음에 비활성이므로 여기서 초기화를 해줌
    }


    void Start()
    {

        //backVol = PlayerPrefs.GetFloat("backvol"); //슬라이더 값 저장, 뒤에 1f는 값이 비어있을때 1로 불러와서 소리 들리게 하려고.
        //backVolume.value = backVol;
        //audios.volume = backVolume.value;

        audios.volume = PlayerPrefs.GetFloat("backvol");
    }


    void Update()
    {
        //SoundSlider();
        audios.volume = BGMSlider.soundVolume;              //슬라이더 바 변경시 뮤직의 사운드 크기도 여기서 변경
    }


    //void SoundSlider()
    //{
    //    audios.volume = backVolume.value;
    //    backVol = backVolume.value;
    //    PlayerPrefs.SetFloat("backvol", backVol);
    //}
        
}


