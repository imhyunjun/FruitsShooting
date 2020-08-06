using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 미리 만들어 놓은 과일을 재활용( 과일 하나)
public class FruitMemoryPool : IDisposable //IEnumerable
{
    class Fruit
    {
        public bool isActive;           //과일을 사용중인지
        public GameObject gameObject;   //저장할 게임 오브젝트
    }

    Fruit[] fruitTable;                                         //과일을 담을 공간
    List<Fruit[]> fruitsList = new List<Fruit[]>();             //과일 여러개 담을 공간

    //public IEnumerator GetEnumerator()
    //{
    //    if (fruitTable == null)
    //    {
    //        yield break;
    //    }

    //    int count = fruitTable.Length;
    //    for (int i = 0; i < count; i++)
    //    {
    //        Fruit fruit = fruitTable[i];
    //        if (fruit.isActive)
    //        {
    //            yield return fruit.gameObject;
    //        }
    //    }
    //}

    //메모리 풀 생성 
    public void Create(GameObject _original, int _count)        //_object는 원본, _count 는 최대 갯수, 
    {
        fruitTable = new Fruit[_count];
        for(int i = 0; i < _count; i++)
        {
            Fruit fruit = new Fruit();
            fruit.isActive = false;
            fruit.gameObject = GameObject.Instantiate(_original) as GameObject; //만들어 둔 과일들 저장
            fruit.gameObject.SetActive(false);
            fruitTable[i] = fruit;
        }
        fruitsList.Add(fruitTable);
    }


    //사용하지 않는 과일 사용
    public GameObject NewFruit(int _fruitOrder)
    {
        Fruit[] tempFruit = fruitsList[_fruitOrder];
        if(fruitsList[_fruitOrder] == null)
        {
            return null;
        }
        for(int i = 0; i < tempFruit.Length; i++)
        {
            if(!tempFruit[i].isActive)
            {
                tempFruit[i].isActive = true;          //사용하지 않는 다면 다시 사용
                tempFruit[i].gameObject.SetActive(true);
                return tempFruit[i].gameObject;
            }
        }
        return null;
    }

    //사용하던 과일 제거
    public void RemoveFruit(GameObject _gameObject, int _fruitOrder)
    {
        Fruit[] tempFruit = fruitsList[_fruitOrder];
        if (tempFruit == null || _gameObject == null)
        {
            return;
        }
        for(int i = 0; i < tempFruit.Length; i++)
        {
            if(tempFruit[i].gameObject == _gameObject)
            {
                tempFruit[i].isActive = false;
                tempFruit[i].gameObject.SetActive(false);
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
