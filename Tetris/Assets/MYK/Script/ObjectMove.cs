using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ObjectManager���� �Ʒ��� ��� �����´�
//��ư�� ���� �����δ�
//���ʹ�ư �Ʒ���ư �����ʹ�ư
//�ٴڿ� �׿��� �����Ѵ�



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
