using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public void DestroyZombie()
    {
        ZombieMemoryPool.ReturnObject(this);
    }

   

}
