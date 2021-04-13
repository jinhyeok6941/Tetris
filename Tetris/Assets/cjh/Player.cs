using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float currtime = 1;      //1초 마다 한 칸씩 아래로 떨어지게
    float checktime;         
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        checktime += Time.deltaTime;

        // 테트리스 객체 움직임 구현
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += Vector3.right;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.position += Vector3.down;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.position += Vector3.up;
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.Rotate(0,0,90);
        }

        if (currtime < checktime)
        {
            transform.position += Vector3.down;
            checktime = 0;
        }
    }
}
