using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawn : MonoBehaviour
{
    public bool enableSpawn = false;
    public GameObject zombie; //Prefab을 받을 public 변수 입니다.

    void SpawnZombie()
    {
        float randomX = Random.Range(-20, 20); //적이 나타날 X좌표를 랜덤으로 생성해 줍니다.
        float randomY = Random.Range(-20, 20); //이건 y좌표 !

        if (enableSpawn)
        {
            GameObject Zombie = (GameObject)Instantiate(zombie, new Vector3(randomX, randomY, 0f), Quaternion.identity); //랜덤한 위치와, 화면 제일 위에서 좀비를 하나 생성함
        }
    }
    void Start()
    {
        InvokeRepeating("SpawnZombie", 3, 2); //3초후 부터, SpawnZombie함수를 2초마다 반복해서 실행 시킵니다.
    }
}
