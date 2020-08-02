﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject fruitPrefab;
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

    
    
        

    FruitMemoryPool fruitPool = new FruitMemoryPool();                    //과일 메모리 풀 생성

    public struct Fruit
    {
        public GameObject gameObject;
        public Vector3 fruitDirVec;
    }

    Fruit[] fruit;

    private void Start()            //초기화
    {
        screenVerticeCoord = Camera.main.ViewportToWorldPoint(new Vector2(1, 0));
        sqrRadius = (screenVerticeCoord - playerPos).sqrMagnitude;

        startTime = Time.time;

        fruitCount = 10;
        fruitPool.Create(fruitPrefab, fruitCount);
        fruit = new Fruit[fruitCount];
        for(int i = 0; i < fruit.Length; i++)
        {
            fruit[i].gameObject = null;
            fruit[i].fruitDirVec = Vector3.zero;
        }
    }

    private void Update()
    {
        playerPos = transform.position;
        shootTimeLeft = Time.time - startTime;

        if (Input.GetMouseButtonDown(0))                                                         
        {
            mousPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            towadMouse = mousPos - playerPos;

            if (shootTimeLeft > fireRate)                                           //미사일 발사
            {
                for(int i = 0; i < fruit.Length; i++)
                {
                    if(fruit[i].gameObject == null)
                    {
                        fruit[i].gameObject = fruitPool.NewFruit();
                        fruit[i].gameObject.transform.position = transform.position;
                        fruit[i].fruitDirVec = towadMouse;
                        fruit[i].gameObject.GetComponent<Rigidbody2D>().velocity = fruit[i].fruitDirVec.normalized * fruitSpeed;
                        break;
                    }
                }
            }
            
        }

        //미사일 삭제 - 우선 거리 위주로, 좀비는 다른 스크립트(FruitCollision에서)
        for (int i = 0; i < fruit.Length; i++)
        {
            if(fruit[i].gameObject)
            {
                Vector2 fruitPos = fruit[i].gameObject.transform.position;
                if((fruitPos- playerPos).sqrMagnitude > sqrRadius )      //원점으로부터 과일의 거리가 일정 거리(radius)보다 멀어지면
                {
                    fruitPool.RemoveFruit(fruit[i].gameObject);
                    fruit[i].gameObject = null;
                    fruit[i].fruitDirVec = Vector2.zero;
                }
            }
        }

        
    }

    private void OnApplicationQuit()
    {
        fruitPool.Dispose();
    }
}
