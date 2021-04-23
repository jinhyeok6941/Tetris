using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    float alpha = 0;
    float dir = 1;
    public Text textTitle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        alpha += 0.01f * dir;
        textTitle.color = new Color(0, 1, 0, alpha);

        if (alpha >= 1 || alpha <= 0) dir *= -1;
    }
    public void OnclickStart()
    {
        SceneManager.LoadScene("MYKScene");
    }
}
