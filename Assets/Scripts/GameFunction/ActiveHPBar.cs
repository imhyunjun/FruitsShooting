using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveHPBar : MonoBehaviour
{
    Slider sliderHP;

    private void Start()
    {
        sliderHP = gameObject.GetComponent<Slider>();
        sliderHP.value = 1f;
    }

    private void Update()
    {
        if (sliderHP.value <= 0)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }
}
