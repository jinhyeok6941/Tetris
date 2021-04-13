using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{

    public GameObject[] tetris = new GameObject[5];
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    /*
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject); 

        int rand = Random.Range(0, 5);

        GameObject tetrisObject = Instantiate(tetris[rand]);
        tetrisObject.transform.position = new Vector3(0, 10, 0);

    }
    */
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
        int rand = Random.Range(0, 5);

        GameObject tetrisObject = Instantiate(tetris[rand]);
        tetrisObject.transform.position = new Vector3(0, 10, 0);
    }
}
