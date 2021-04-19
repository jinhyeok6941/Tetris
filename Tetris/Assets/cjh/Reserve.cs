using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reserve : MonoBehaviour
{
    public float time,currtime = 1;
    public int checktime = 1;
    public Text score;
    public Text grade;
    public int scoreCount = 0;
    public GameObject [] tetris;    //예약 테트리스 모음
    //public static Reserve re;
    // Start is called before the first frame update
    //private void Awake()
    //{
    //    re = this;
    //}
    public int rand;
    void Start()
    {
        SetOnTetris();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        //print(currtime + "   " + checktime + "    " + time);
        if (time / 10 >= checktime && currtime > 0.3f)
        {   
            currtime -= 0.2f;
            checktime++;
            grade.text = "Grade : " + checktime.ToString();
            print(time);
        }
        score.text = "Score : " + scoreCount.ToString();
        
    }

    public void SetOnTetris()
    {
        rand = Random.Range(0, 5);
        tetris[rand].SetActive(true);
    }

    public void SetOffTetris()
    {
        tetris[rand].SetActive(false);
    }
}
