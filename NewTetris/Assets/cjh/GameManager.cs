using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject [] tetris;
    // Start is called before the first frame update
    void Start()
    {
        int rand = Random.Range(0, 7);
        GameObject tetrisObject = Instantiate(tetris[rand]);
        tetrisObject.transform.position = new Vector3(4, 18, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
