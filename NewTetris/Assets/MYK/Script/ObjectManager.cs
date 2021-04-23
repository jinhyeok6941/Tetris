using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public GameObject [] objectFactory = new GameObject[7];
    public GameObject objectManager;
    
    //일정시간(생성시간)
    float createTime = 2;
    //흐르는 시간(현재시간)
    float currTime;
    // Start is called before the first frame update
    void Start()
    {
        //objectFactory[0]=
        
       // objects.transform.position = new Vector3(4.9f, 20, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //currTime을 흐르게 한다(증가시킨다)
        currTime += Time.deltaTime;
        //만약에 일정시간이 지나면
        //if(일정시간<흘러간시간)
        if (createTime < currTime)
        {
            GameObject objects = Instantiate(objectFactory[Random.Range(0, 6)]);
            objects.transform.position = transform.position;
            currTime = 0; //초기화
            //5. createTime을 랜덤하게 설정하자
            createTime = Random.Range(2f, 5f);
        }
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
