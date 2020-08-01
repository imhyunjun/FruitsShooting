using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
    public void QuitBtn() //종료하기
    {
        Debug.Log("종료");
         Application.Quit();
    }
}
