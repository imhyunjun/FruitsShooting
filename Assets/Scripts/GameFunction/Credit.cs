using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        GameObject.Destroy(GameObject.Find("MainBGM")); //메인 bgm 파괴
        Invoke("SceneLoad", 26f);
    }

    void SceneLoad()
    {
        SceneManager.LoadScene("Main");  

    }
}
