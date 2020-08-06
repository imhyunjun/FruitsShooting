using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie2Spawn : MonoBehaviour
{
    void SpawnZombie2()
    {
        float randomX = Random.Range(-20, 20); //적이 나타날 X좌표를 랜덤으로 생성해 줍니다.
        float randomY = Random.Range(-20, 20); //이건 y좌표 !
        var zombie = ZombieMemoryPool.GetObject();
        var direction = new Vector2(randomX, randomY);
        zombie.transform.position = direction;

    }
    void Start()
    {
        InvokeRepeating("SpawnZombie2", 3, 3); //3초후 부터, SpawnZombie함수를 1초마다 반복해서 실행 시킵니다.
    }

}
