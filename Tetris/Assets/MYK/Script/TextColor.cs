using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextColor : MonoBehaviour
{
    public float [] rgb;
    public Text text;
    float light;
    int i = 0;
    public float addcolor = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
        print("½ÃÀÛ");
    }

    // Update is called once per frame
    void Update()
    {
        if (rgb[i] >= 1 || rgb[i] <=0)
        {
            addcolor *= -1;
            i++;
        }
        light += 0.01f;
        i %= rgb.Length;
        rgb[i] += addcolor;
        text.color = new Color(rgb[0], rgb[1] ,rgb[2] , light); 
    }
}
