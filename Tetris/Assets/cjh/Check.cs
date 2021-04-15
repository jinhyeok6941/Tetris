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
            // 내부 사작형의 좌표를 구합니다. (float은 필요없기에 int로 변환합니다.)
            int positionX = Mathf.RoundToInt(transform.GetChild(i).position.x);
            int positionY = Mathf.RoundToInt(transform.GetChild(i).position.y);
       
            print("x : " + positionX + "  y : " + positionY);
        }
    }


}
