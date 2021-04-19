using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBomb : MonoBehaviour
{
    public GameObject explosionFactory;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //폭발 효과 공장에서 폭발효과 생성
        GameObject effect = Instantiate(explosionFactory);
        effect.transform.position = gameObject.transform.position;

        //3초 있다가 파괴하자
        //Destroy(gameObject,3);
        Invoke("DestroyObject", 3);
    }

    void DestroyObject()
    {
        Destroy(gameObject);
    }
}
