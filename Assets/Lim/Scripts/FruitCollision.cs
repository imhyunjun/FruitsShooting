using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitCollision : MonoBehaviour
{
   
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.transform.CompareTag("Zombie"))         //좀비 부딪히면 사라짐
        {
            gameObject.SetActive(false);
        }
    }
}
