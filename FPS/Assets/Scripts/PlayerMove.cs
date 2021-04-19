using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    float JumpPower = 10;
    //케릭터 컨트롤러
    CharacterController cc;
    //속력
    float speed = 5;
    //중력
    float gravity = -20;
    float yVelocity = 0;
    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //바닥에 닿아 있다면 yVelocity를 0으로
        if (cc.isGrounded)
        {
            yVelocity = 0;
        }
        //키보드 값 받아오기.
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
      
        //방향 제어
        Vector3 dir = new Vector3(h, 0, v);
        dir = dir.normalized;

        //방향의 기준점(Player)을 바꿔서 카메라(World 좌표)를 기준으로 바꿔준다.
        dir = Camera.main.transform.TransformDirection(dir);
        dir.y = 0;

        //점프를 누르면 yVelocity <- jumpPower
        if (Input.GetButtonDown("Jump"))
        {
            yVelocity = JumpPower;
        }
        dir.y = yVelocity;
        yVelocity += gravity * Time.deltaTime;

        //transform.position += dir * speed * Time.deltaTime;

        cc.Move(dir * speed * Time.deltaTime);
    }
}
