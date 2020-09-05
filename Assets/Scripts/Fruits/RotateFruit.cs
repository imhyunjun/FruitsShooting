using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateFruit : MonoBehaviour
{
    [SerializeField]
    private float howMuchRotate;                        //한번에 얼마나 회전할지

    private void Start()
    {
        howMuchRotate = 200f;
    }

    private void FixedUpdate()
    {
        transform.Rotate(new Vector3(0, 0, howMuchRotate * Time.fixedDeltaTime));
    }
}
