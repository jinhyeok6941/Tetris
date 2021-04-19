using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    float JumpPower = 10;
    //�ɸ��� ��Ʈ�ѷ�
    CharacterController cc;
    //�ӷ�
    float speed = 5;
    //�߷�
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
        //�ٴڿ� ��� �ִٸ� yVelocity�� 0����
        if (cc.isGrounded)
        {
            yVelocity = 0;
        }
        //Ű���� �� �޾ƿ���.
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
      
        //���� ����
        Vector3 dir = new Vector3(h, 0, v);
        dir = dir.normalized;

        //������ ������(Player)�� �ٲ㼭 ī�޶�(World ��ǥ)�� �������� �ٲ��ش�.
        dir = Camera.main.transform.TransformDirection(dir);
        dir.y = 0;

        //������ ������ yVelocity <- jumpPower
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
