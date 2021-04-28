using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonColor : MonoBehaviour
{
    public float[] rgb;
    public Image btn;
    float light;
    int i = 0;
    public float addcolor = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (rgb[i] >= 1 || rgb[i] <= 0)
        {
            addcolor *= -1;
            i++;
        }
        light += 0.005f;
        i %= rgb.Length;
        rgb[i] += addcolor;
        btn.color = new Color(rgb[0], rgb[1], rgb[2], light);
    }

    public void OnClickExit()
    {
        Application.Quit();
    }
}
