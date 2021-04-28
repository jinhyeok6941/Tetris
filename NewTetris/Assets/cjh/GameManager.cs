using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public Text gradeUp;
    public bool gameover = true;
    public string [] gradeText;
    int gradeTextIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        gminstance = this;
        CreateTetris1();
        CreateTetrisEffect();
        tetris1[tetrisIndex].SetActive(true);
    }
    private void Update()
    {
        if (!gameover && gradeTextIndex < gradeText.Length)
        {
            StartCoroutine(GradeUp());
        }  
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    IEnumerator GradeUp()
    {
        while (gradeTextIndex < gradeText.Length)
        {
            gradeUp.text += gradeText[gradeTextIndex];
            gradeTextIndex++;
            yield return new WaitForSeconds(3);
        }
    }

    void CreateTetris1()                 //테트리스 1 50개 생성
    {
        for(int i=0;i<200;i++)
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
