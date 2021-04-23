using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParents : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount == 0)   //자식들이 전부 Destroy 되었을 때 비활성화되어 남아있는 부모 삭제.
            Destroy(gameObject);
    }
}
