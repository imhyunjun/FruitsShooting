using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMemoryPool : MonoBehaviour
{


    public static ZombieMemoryPool Instance;

    [SerializeField]
    private List<GameObject> zombieList = new List<GameObject>();
    private List<Queue<Zombie>> poolingObjectQueue = new List<Queue<Zombie>>();


    private void Awake()//오브젝트 풀 초기화
    {
        Instance = this;//오브젝트풀 인스턴스에 자기 할당화 (싱글톤)
        for(int i = 0; i<zombieList.Count; i++) //
        {
            poolingObjectQueue.Add(new Queue<Zombie>());

            Initialize(50, i);
        }

    }

    private void Initialize(int initCount, int id)// 게임 시작전 미리 게임 오브젝트를 만들어 놓는다(과부화방지)
    {
        for(int i = 0; i<initCount; i++)
        {
            poolingObjectQueue[id].Enqueue(CreateNewObject(id));
        }
    }

    private Zombie CreateNewObject(int id)//풀링오브젝트프리팹으로부터 새 게임오브젝트를 만든 뒤 비활성화해서 반환
    {
        var newObj = Instantiate(zombieList[id]).GetComponent<Zombie>();
        newObj.ID = id;
        newObj.gameObject.SetActive(false);
        newObj.transform.SetParent(transform);
        return newObj;
    }

    public static Zombie GetObject(int id) // 오브젝트풀이 가지고있는 게임오브젝트를 빌려줌. 없으면 새로운 오브젝트 생성해서 빌려줌
    {
        if(Instance.poolingObjectQueue.Count > 0)
        {
            var obj = Instance.poolingObjectQueue[id].Dequeue();
            obj.transform.SetParent(null);
            obj.gameObject.SetActive(true);
            return obj;
        }

        else
        {
            var newObj = Instance.CreateNewObject(id);
            newObj.gameObject.SetActive(true);
            newObj.transform.SetParent(null);
            return newObj;
        }
    }

    public static void ReturnObject(Zombie obj,int id)//빌려준거 돌려받는 함수. 돌려받으면 비활성화.
    {
        obj.gameObject.SetActive(false);
        obj.transform.SetParent(Instance.transform);
        Instance.poolingObjectQueue[id].Enqueue(obj);
    }
}
