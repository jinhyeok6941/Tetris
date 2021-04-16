using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reserve : MonoBehaviour
{

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
