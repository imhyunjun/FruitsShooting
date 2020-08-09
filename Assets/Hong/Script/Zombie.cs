using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public int ID;


    public void DestroyZombie(int id)
    {
        ZombieMemoryPool.ReturnObject(this, id);
    }
}
