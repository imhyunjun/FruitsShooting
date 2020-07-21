using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 미리 만들어 놓은 과일을 재활용( 과일 하나)
public class FruitMemoryPool : IEnumerable, IDisposable
{
    class Fruit
    {
        public bool isActive;           //과일을 사용중인지
        public GameObject gameObject;   //저장할 게임 오브젝트
    }

    Fruit[] fruitTable;                 //과일을 담을 공간

    public IEnumerator GetEnumerator()
    {
        if(fruitTable == null)
        {
            yield break;
        }

        int count = fruitTable.Length;
        for(int i = 0; i < count; i ++)
        {
            Fruit fruit = fruitTable[i];
            if(fruit.isActive)
            {
                yield return fruit.gameObject;
            }
        }
    }

    //메모리 풀 생성 
    public void Create(GameObject _original, int _count)        //_object는 원본, _count 는 최대 갯수, 
    {
        Dispose();                                          //메모리 관리
        fruitTable = new Fruit[_count];
        for(int i = 0; i < _count; i++)
        {
            Fruit fruit = new Fruit();
            fruit.isActive = false;
            fruit.gameObject = GameObject.Instantiate(_original) as GameObject; //만들어 둔 과일들 저장
            fruit.gameObject.SetActive(false);
            fruitTable[i] = fruit;
        }

    }


    //사용하지 않는 과일 사용
    public GameObject NewFruit()
    {
        if(fruitTable == null)
        {
            return null;
        }
        for(int i = 0; i < fruitTable.Length; i++)
        {
            if(!fruitTable[i].isActive)
            {
                fruitTable[i].isActive = true;          //사용하지 않는 다면 다시 사용
                fruitTable[i].gameObject.SetActive(true);
                return fruitTable[i].gameObject;
            }
        }
        return null;
    }

    //사용하던 과일 제거
    public void RemoveFruit(GameObject _gameObject)
    {
        if(fruitTable == null || _gameObject == null)
        {
            return;
        }
        for(int i = 0; i < fruitTable.Length; i++)
        {
            if(fruitTable[i].gameObject == _gameObject)
            {
                fruitTable[i].isActive = false;
                fruitTable[i].gameObject.SetActive(false);
                break;
            }
        }
    }

    //모든 과일 사용 종료
    public void ClearFruit()
    {
        if(fruitTable == null)
        {
            return;
        }
        for(int i = 0; i < fruitTable.Length; i++)
        {
            if(fruitTable[i] != null && fruitTable[i].isActive)
            {
                fruitTable[i].isActive = false;
                fruitTable[i].gameObject.SetActive(false);
            }
        }
    }


    public void Dispose()
    {
        if(fruitTable == null)
        {
            return;
        }
        for(int i = 0; i < fruitTable.Length; i++)
        {
            GameObject.Destroy(fruitTable[i].gameObject);
        }
        fruitTable = null;
    }


}
