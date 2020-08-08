using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public int ID;

    public void DestroyZombie1()
    {
        ZombieMemoryPool.ReturnObject(this, 0);
    }

    public void DestroyZombie2()
    {
        ZombieMemoryPool.ReturnObject(this, 1);
    }

}