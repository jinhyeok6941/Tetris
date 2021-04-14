using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public GameObject [] objectFactory = new GameObject[7];
    public GameObject objectManager;

    // Start is called before the first frame update
    void Start()
    {
       //objectFactory[0]=
    }

    // Update is called once per frame
    void Update()
    {
        //Object가 바닥에 닿으면
        //if()
        //{
        //    //Object공장에서 Object를 만든다
        //    GameObject object = Instantiate(objectFactory);
        //    //만들어진 Object를 ObjectManager 위치에 놓는다
        //    object.transform.position= transform.position
        //}

        //지정한 위치에서 나오게
        //랜덤 함수를 활용해서 나오게 범위를 0~6 Random.range(7)
        //객체 생성하기  Instantiate<objectFactory[랜덤값]> 

    }
}
