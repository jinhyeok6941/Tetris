using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ObjectManager에서 아래로 계속 내려온다
//버튼에 따라 움직인다
//왼쪽버튼 아래버튼 오른쪽버튼
//바닥에 쌓여서 정지한다



public class ObjectMove : MonoBehaviour
{
    public float speed = 1;
    Vector3 dir;

    //public GameObject[] models;
    // Start is called before the first frame update
    void Start()
    {
        speed = 1;
        dir = Vector3.down;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            dir = new Vector3(1, 0, 0);
            transform.position += dir;
        }
        transform.position += dir * speed * Time.deltaTime;
    }
}
