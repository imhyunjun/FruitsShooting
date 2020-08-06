using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie2Collision : Zombie
{
    public GameObject zombie;

    public int MaxHealth = 2;
    public int Health = 2;


    private void OnTriggerEnter2D(Collider2D collision) // 오렌지 태그를 가진 오브젝트를 만나면 좀비 사라짐
    {
        if (collision.gameObject.tag == "Orange")
        {
            Health -= 1;
        }
    }


    public void Die()
    {
        if(Health == 0)
        DestroyZombie(); }

}

