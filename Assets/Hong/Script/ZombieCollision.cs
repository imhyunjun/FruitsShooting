using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieCollision : MonoBehaviour
{
    public GameObject zombie;

    private void OnTriggerEnter2D(Collider2D collision) // 오렌지 태그를 가진 오브젝트를 만나면 좀비 사라짐
    {
        if (collision.gameObject.tag == "Orange")
        {
            zombie.gameObject.SetActive(false);
        }
    }
}
