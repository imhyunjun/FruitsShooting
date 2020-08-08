using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawn : MonoBehaviour
{

    void SpawnZombie(int id)
    {
        float randomX = Random.Range(-20, 20); //적이 나타날 X좌표를 랜덤으로 생성해 줍니다.
        float randomY = Random.Range(-20, 20); //이건 y좌표 !
        var zombie = ZombieMemoryPool.GetObject(id);
        var direction = new Vector2(randomX, randomY);
        zombie.transform.position = direction;

    }


    void Start()
    {
        StartCoroutine(spawnZombie(0, 2)); //0번좀비 2초마다
        StartCoroutine(spawnZombie(1, 4)); //1번좀비 4초마다
    }

    IEnumerator spawnZombie(int id, float second)
    {
        while (true)
        {
            SpawnZombie(id);
            yield return new WaitForSeconds(second);//second만큼 대기
        }
    }

}

//static 