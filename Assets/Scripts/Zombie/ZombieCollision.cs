using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieCollision : Zombie
{
    Slider zombieHP;            //좀비 hp바
    float tempHP;               //임시 hp

    private void Start()
    {
        zombieHP = gameObject.transform.GetChild(0).transform.GetChild(0).GetComponent<Slider>();
        currentHP = MaxHP;
        tempHP = MaxHP;
    }
    private void OnTriggerEnter2D(Collider2D collision)                           // 오렌지 태그를 가진 오브젝트를 만나면 좀비 사라짐
    {
        //if (collision.gameObject.tag == "Berry")
        //{
        //    DestroyZombie(0);
        //}
        //if (collision.gameObject.tag == "Banana")
        //{
        //    DestroyZombie(1);
        //}

        if(collision.gameObject.CompareTag(obstacle))
        {
            gameObject.GetComponent<AudioSource>().Play();
            switch (obstacle)
            {
                case "Berry": tempHP = 0f;
                    break;
                case "Banana": tempHP -= 30f;                       //바나나 맞으면 30씩, 나중에 비율로도 가능
                    break;
                default:
                    break;
            }

            currentHP = tempHP;
            zombieHP.value = currentHP / MaxHP;

            if (currentHP <= 0)
            {
                StartCoroutine(IZombieDead());
                AchievementPlayer.GetInstance().playerKillCount++;
                PlayerPrefs.SetInt("PlayerKill", AchievementPlayer.GetInstance().playerKillCount);              //죽을 때마다 카운트 증가
            }
        }
    }

    IEnumerator IZombieDead()
    {
        yield return new WaitForSeconds(0.1f);
        ZombieMemoryPool.ReturnObject(this, 0);
    }




}
