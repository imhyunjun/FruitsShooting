using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject strawberryPrefab;
    public GameObject bananaPrefab;
    public Camera cinemachine;

    public float fireRate;          //발사 간격
    float startTime;
    float shootTimeLeft;            //다음 발사까지 시간

    [SerializeField]
    int fruitCount;                 //과일 갯수

    public float fruitSpeed;        //과일 날아가는 속도

    Vector2 mousPos;                //마우스좌표
    Vector2 playerPos;              //플레이어
    Vector2 towadMouse;             //마우스까지의 벡터

    float sqrRadius;                //스크린 꼭지점에서 플레이어까지 거리의 제곱
    Vector2 screenVerticeCoord;     //스크린 맨 오른쪽 좌표

    FruitMemoryPool fruitPool = new FruitMemoryPool();                      //과일 메모리 풀 생성
    int selected;                   //선택된 번호

    List<Fruit[]> listOfFruits = new List<Fruit[]>();                       //딸기, 바나나의 배열을 담는 리스트

    struct Fruit                    //일단 구조체로 정리
    {
        public GameObject gameObject;
        public Vector3 fruitDirVec;
    }
   
    Fruit[] strawberry;             //딸기들  담을 배열
    Fruit[] banana;                 //바나나
    
    private void Start()                //초기화
    {
        screenVerticeCoord = Camera.main.ViewportToWorldPoint(new Vector2(1, 0));
        sqrRadius = (2 * (screenVerticeCoord - playerPos)).sqrMagnitude;

        startTime = Time.time;

        fruitCount = 50;
        fruitPool.Create(strawberryPrefab, fruitCount);
        fruitPool.Create(bananaPrefab, fruitCount);

        strawberry = new Fruit[fruitCount];
        banana = new Fruit[fruitCount];

        selected = 0;                                               //처음 값은 0

        for (int i = 0; i < fruitCount; i++)
        {
            strawberry[i].gameObject = null;
            strawberry[i].fruitDirVec = Vector3.zero;

            banana[i].gameObject = null;
            banana[i].fruitDirVec = Vector3.zero;
        }
        listOfFruits.Add(strawberry);                                   //리스트에 과일들 추가 딸기: 0 바나나 : 1
        listOfFruits.Add(banana);
    }

    private void Update()
    {
        playerPos = transform.position;
        shootTimeLeft = Time.time - startTime;

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selected = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            selected = 1;
        }

        Fruit[] currentFruit = listOfFruits[selected];   //현재 쏠 과일

        if (Input.GetMouseButtonDown(0) && Time.timeScale == 1)                                                         
        {
            mousPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            towadMouse = mousPos - playerPos;
   
            if (shootTimeLeft > fireRate)                                               //미사일 발사
            {
                for(int i = 0; i < currentFruit.Length; i++)
                {
                    if(currentFruit[i].gameObject == null)
                    {
                        currentFruit[i].gameObject = fruitPool.NewFruit(selected);
                        currentFruit[i].gameObject.transform.position = transform.position;
                        currentFruit[i].fruitDirVec = towadMouse;
                        currentFruit[i].gameObject.GetComponent<Rigidbody2D>().velocity = currentFruit[i].fruitDirVec.normalized * fruitSpeed;
                        break;
                    }
                }
            }
            
        }

        //미사일 삭제 - 우선 거리 위주로, 좀비는 다른 스크립트(FruitCollision에서)
        for (int i = 0; i < currentFruit.Length; i++)
        {
            if(currentFruit[i].gameObject)
            {
                Vector2 fruitPos = currentFruit[i].gameObject.transform.position;
                if((fruitPos- playerPos).sqrMagnitude > sqrRadius )      //원점으로부터 과일의 거리가 일정 거리(radius)보다 멀어지면
                {
                    fruitPool.RemoveFruit(currentFruit[i].gameObject, selected);
                    currentFruit[i].gameObject = null;
                    currentFruit[i].fruitDirVec = Vector2.zero;
                }
            }
        }

        
    }

    private void OnApplicationQuit()
    {
        fruitPool.Dispose();
    }
}
