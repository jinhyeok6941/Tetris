using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public GameObject [] objectFactory = new GameObject[7];
    public GameObject objectManager;
    
    //�����ð�(�����ð�)
    float createTime = 2;
    //�帣�� �ð�(����ð�)
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
        //currTime�� �帣�� �Ѵ�(������Ų��)
        currTime += Time.deltaTime;
        //���࿡ �����ð��� ������
        //if(�����ð�<�귯���ð�)
        if (createTime < currTime)
        {
            GameObject objects = Instantiate(objectFactory[Random.Range(0, 6)]);
            objects.transform.position = transform.position;
            currTime = 0; //�ʱ�ȭ
            //5. createTime�� �����ϰ� ��������
            createTime = Random.Range(2f, 5f);
        }
        //Object�� �ٴڿ� ������
        //if()
        //{
        //    //Object���忡�� Object�� �����
        //    GameObject object = Instantiate(objectFactory);
        //    //������� Object�� ObjectManager ��ġ�� ���´�
        //    object.transform.position= transform.position
        //}

        //������ ��ġ���� ������
        //���� �Լ��� Ȱ���ؼ� ������ ������ 0~6 Random.range(7)
        //��ü �����ϱ�  Instantiate<objectFactory[������]> 

    }
}
