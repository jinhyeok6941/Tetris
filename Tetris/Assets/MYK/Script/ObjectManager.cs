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
        //Object�� �ٴڿ� ������
        if()
        {
            //Object���忡�� Object�� �����
            GameObject object = Instantiate(objectFactory);
            //������� Object�� ObjectManager ��ġ�� ���´�
            object.transform.position= transform.position
        }


    }
}
