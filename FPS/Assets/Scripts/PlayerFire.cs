using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    float throwPower = 750;
    public GameObject bombFactory;
    public Transform firePos;
    public GameObject bulleteffect;

    // Update is called once per frame
    void Update()
    {
        //���콺 ������ ��ư
        if (Input.GetButtonDown("Fire2"))
        {
            GameObject Bomb = Instantiate(bombFactory);
            Bomb.transform.position = firePos.position;
            Rigidbody rb = Bomb.GetComponent<Rigidbody>();
            //ī�޶� �������� ���� ����
            rb.AddForce(Camera.main.transform.forward * throwPower);
        }
        //���콺 ���� ��ư
        if (Input.GetButtonDown("Fire1"))
        {
            //ī�޶� �չ������� �߻�Ǵ� Ray�� �����.
            Ray ray = new Ray(Camera.main.transform.position
                ,Camera.main.transform.forward);
            //�ε��� ������Ʈ�� ������ ��� ����
            RaycastHit hit;
            //�� Ray ��򰡿� �ε��� ������ ��� ����
            if (Physics.Raycast(ray, out hit))
            {
                //ȿ�� �ߵ�
                //�ε��� ���� ������Ʈ�� �����Ϸ��� hit.transform.gameObject.name;
                bulleteffect.transform.position = hit.point;
                bulleteffect.transform.forward = hit.normal;
                //��ƼŬ ����
                ParticleSystem ps = bulleteffect.GetComponent<ParticleSystem>();
                ps.Play();
                //���� ����
                AudioSource audio = bulleteffect.GetComponent<AudioSource>();
                audio.Play();
             }
        }
    }
}
