using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    public GameObject buttonPanel;

    private void OnTriggerEnter2D(Collider2D _collision)
    {
        //좀비와 부딪히면
        if (_collision.transform.CompareTag("Zombie"))  
        {
            Time.timeScale = 0;                         //게임 끝
            buttonPanel.SetActive(true);                //버튼 panel 활성화
        }
    }
}
