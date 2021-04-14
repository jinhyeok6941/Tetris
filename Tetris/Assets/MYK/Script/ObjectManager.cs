using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public GameObject objectFactory;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Object가 바닥에 닿으면
        if()
        {
            //Object공장에서 Object를 만든다
            GameObject object = Instantiate(objectFactory);
            //만들어진 Object를 ObjectManager 위치에 놓는다
            object.transform.position= transform.position
        }


    }
}
