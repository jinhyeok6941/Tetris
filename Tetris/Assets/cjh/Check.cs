using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckPosition();
    }

    void CheckPosition()
    {

        for (int i = 0; i < transform.childCount; i++)
        {
            // ���� �������� ��ǥ�� ���մϴ�. (float�� �ʿ���⿡ int�� ��ȯ�մϴ�.)
            int positionX = Mathf.RoundToInt(transform.GetChild(i).position.x);
            int positionY = Mathf.RoundToInt(transform.GetChild(i).position.y);
       
            print("x : " + positionX + "  y : " + positionY);
        }
    }


}
