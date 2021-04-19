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
        //���� ȿ�� ���忡�� ����ȿ�� ����
        GameObject effect = Instantiate(explosionFactory);
        effect.transform.position = gameObject.transform.position;

        //3�� �ִٰ� �ı�����
        //Destroy(gameObject,3);
        Invoke("DestroyObject", 3);
    }

    void DestroyObject()
    {
        Destroy(gameObject);
    }
}
