using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingLoad : MonoBehaviour
{
    private void Start()
    {
        Invoke("EndingLoading", 60f);
    }

    void EndingLoading()
    {
        SceneManager.LoadScene("Ending");          //엔딩씬 로드

        GameObject.Destroy(GameObject.Find("MainBGM")); //메인 bgm 파괴
    }


}
