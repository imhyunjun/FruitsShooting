using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBar : MonoBehaviour
{
    private void Start()
    {
        transform.position = Camera.main.WorldToScreenPoint(transform.parent.transform.parent.position + new Vector3(0, 1.2f, 0));      //HP바가 부모의 부모(좀비)를 따라가게
    }
    private void FixedUpdate()
    {
        transform.position = Camera.main.WorldToScreenPoint(transform.parent.transform.parent.position + new Vector3(0, 1.2f, 0));
    }
}
