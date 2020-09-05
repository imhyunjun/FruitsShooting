using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public int ID;
    public GameObject zombie;
    public string obstacle;
    public float MaxHP;
    protected float currentHP;

    public void DestroyZombie()               //좀비 1 : 0, 좀비2 : 1;
    {
        ZombieMemoryPool.ReturnObject(this, 0);
    }
}
