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

    public GameObject tetrisEffectFactory;
    GameObject tetrisEffect;
    public List<GameObject> tetrisEffectArray = new List<GameObject>();

    public List<int> Reserve = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        gminstance = this;
        CreateTetris1();
        CreateTetrisEffect();
        tetris1[tetrisIndex].SetActive(true);
    }

    void CreateTetris1()                 //테트리스 1 50개 생성
    {
        for(int i=0;i<100;i++)
        {
            int rand = Random.Range(0, 7);
            tetrisObject = Instantiate(tetris[rand]);
            tetrisObject.SetActive(false);
            tetris1.Add(tetrisObject);
            Reserve.Add(rand);
        }    
    }

    void CreateTetrisEffect()
    {
        for (int i = 0; i < 10; i++)
        {
            tetrisEffect = Instantiate(tetrisEffectFactory);
            tetrisEffectArray.Add(tetrisEffect);
        }
    }
}
