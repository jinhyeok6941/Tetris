using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallColor : MonoBehaviour
{
    public Material wall;
    public float[] rgb;
    int i = 0;
    public float addcolor = 0.01f;
    public GameObject reObj;
    Reserve re;
    // Start is called before the first frame update
    void Start()
    {
        reObj = GameObject.Find("ReserveTetris");
        re = reObj.GetComponent<Reserve>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rgb[i] >= 1 || rgb[i] <= 0)
        {
            addcolor *= -1;
            i++;
        }
        i %= rgb.Length;
        rgb[i] += ((float)re.maxY/2)*addcolor;
        wall.color = new Color(rgb[0], rgb[1], rgb[2], 1);
    }
}
