using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotate : MonoBehaviour
{
    float rotX;
    float rotY;
    float rotSpeed = 100;
    public bool useRotVertical;
    public bool useRotHorizontal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mx = Input.GetAxis("Mouse X");
        float my = Input.GetAxis("Mouse Y");

        //�Է¹��� ������ ȸ���� ���ϱ�
        if (useRotHorizontal == true)
            rotX += mx * rotSpeed * Time.deltaTime;
        if (useRotVertical == true)
            rotY += my * rotSpeed * Time.deltaTime;

        //���� ȸ���ϴ� ���� ����
        rotY = Mathf.Clamp(rotY, -90, 90);

        //transform.localEulerAngles += new Vector3(-rotY, rotX, 0);
    }
}
