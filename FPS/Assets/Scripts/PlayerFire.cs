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
        //마우스 오른쪽 버튼
        if (Input.GetButtonDown("Fire2"))
        {
            GameObject Bomb = Instantiate(bombFactory);
            Bomb.transform.position = firePos.position;
            Rigidbody rb = Bomb.GetComponent<Rigidbody>();
            //카메라 방향으로 힘을 전달
            rb.AddForce(Camera.main.transform.forward * throwPower);
        }
        //마우스 왼쪽 버튼
        if (Input.GetButtonDown("Fire1"))
        {
            //카메라 앞방향으로 발사되는 Ray를 만든다.
            Ray ray = new Ray(Camera.main.transform.position
                ,Camera.main.transform.forward);
            //부딪힌 오브젝트의 정보를 담는 변수
            RaycastHit hit;
            //그 Ray 어딘가에 부딪힌 정보를 담는 변수
            if (Physics.Raycast(ray, out hit))
            {
                //효과 발동
                //부딪힌 게임 오브젝트에 접근하려면 hit.transform.gameObject.name;
                bulleteffect.transform.position = hit.point;
                bulleteffect.transform.forward = hit.normal;
                //파티클 실행
                ParticleSystem ps = bulleteffect.GetComponent<ParticleSystem>();
                ps.Play();
                //사운드 실행
                AudioSource audio = bulleteffect.GetComponent<AudioSource>();
                audio.Play();
             }
        }
    }
}
