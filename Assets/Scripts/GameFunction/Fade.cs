using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    public Image fade;
    public GameObject canvas;
    float fades = 1.0f;
    float time = 0;

    private void Start()
    {
        Invoke("delete", 1.1f);
    }

    private void Update()
    {
        time += Time.deltaTime;
        if (fades>0.0f && time >= 0.1f)
        {
            fades -= 0.1f;
            fade.color = new Color(0, 0, 0, fades);
            time = 0;
        }
        else if (fades <= 0.0f)
        {
            time = 0;
        }
    }

    private void delete()
    {
        canvas.SetActive(false);
    }
}
