using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextColor : MonoBehaviour
{
    public float [] rgb;
    public Text text;
    float light = 1;
    int i = 0;
    float addcolor = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rgb[i] >= 1)
        {
            addcolor = -0.1f;
            i++;
        }
        else if (rgb[i] <= 0)
        {
            addcolor = 0.1f;
            i++;
        }

        i %= rgb.Length;
        rgb[i] += addcolor;
        text.color = new Color(rgb[0], rgb[1] ,rgb[2] , light); 
    }
}
