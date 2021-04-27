using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject [] tetris;
    GameObject tetrisObject;
    public List<GameObject> tetris1 = new List<GameObject>();
    public int tetrisIndex = 0;
    public static GameManager gminstance;
    // Start is called before the first frame update
    void Start()
    {
        CreateTetris1();
        tetris1[tetrisIndex].SetActive(true);
        //tetris1[tetrisIndex].transform.position = new Vector3(4, 18, 0);
    }

    void CreateTetris1()                 //테트리스 1 50개 생성
    {
        for(int i=0;i<100;i++)
        {
            int rand = Random.Range(0, 7);
            tetrisObject = Instantiate(tetris[rand]);
            tetrisObject.SetActive(false);
            tetris1.Add(tetrisObject);
        }    
    }
}
