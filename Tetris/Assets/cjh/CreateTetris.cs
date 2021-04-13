using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTetris : MonoBehaviour
{
    public GameObject tetrisPoint;
    // Start is called before the first frame update
    void Start()
    {
        string [] tetrisObject = { "TetrisPart3", "TetrisPart2", "TetrisPart1", "TetrisPart4", "TetrisPart5" };
        for (int i = 0; i < 5; i++) {
            GameObject findtetris = GameObject.Find(tetrisObject[i]);

            GameObject tetris = Instantiate(findtetris);
            tetris.transform.position = new Vector3(0, 50, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
