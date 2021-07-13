using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Reserve : MonoBehaviour
{
    public float time,currtime = 1;
    public int nowGrade;      
    public Text score;
    public Text grade;
    public Text textTime;
    public Text line;
    public Text bestScore;
    public int scoreCount = 0;
    public GameObject [] tetris;    //���� ��Ʈ���� ����

    public GameObject obstacleFactory;
    public List<GameObject> creatOst = new List<GameObject>();
    public List<GameObject> destOst = new List<GameObject>();
    int ostCnt = 191;
    public int obIndex = 0;         //��ֹ� ���� �ε���
    public int maxY;        //��Ʈ���� ��ǥ�� �ִ� ���� ��
    public GameObject retry;
    public int reserveIndex;
    int gradeindex;
    int compareScore;
    
    //public static Reserve re;
    // Start is called before the first frame update
    //private void Awake()
    //{
    //    re = this;
    //}
    public int rand;
    public int ABCD;
    int index;
    void Start()
    {
        compareScore = PlayerPrefs.GetInt("BS");
        bestScore.text = "SCO��E : " + compareScore.ToString();
        SetOnTetris();
        //CreateObstacle();
        nowGrade = SceneManager.GetActiveScene().buildIndex;  //���� �ε��� �� �ޱ�.
        grade.text = "Grade : " + nowGrade.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        textTime.text = "TIME : " + ((int)time).ToString();
        score.text = "SCO��E : " + scoreCount.ToString();
        line.text = "LINE : " + (scoreCount / 5).ToString();
        if (compareScore <= scoreCount)
        {
            compareScore = scoreCount;
            PlayerPrefs.SetInt("BS", compareScore);
            bestScore.text = "SCO��E : " + compareScore.ToString(); 
        }

    }

    public void SetOnTetris()
    {
        index = GameManager.gminstance.Reserve[GameManager.gminstance.tetrisIndex + 1];
        for(int i = 0; i < 7; i++)
        {
            if (tetris[i].active)
                tetris[i].SetActive(false);
        }
        tetris[index].SetActive(true);
    }

    void CreateObstacle()
    {
        for (int i = 0; i < ostCnt; i++)         //��ֹ� ��ü ����
        {
            GameObject obstacle = Instantiate(obstacleFactory);
            obstacle.SetActive(false);
            creatOst.Add(obstacle);
        }
    }
    public void Retry()
    {
        GameOverBG over = retry.GetComponent<GameOverBG>();
        gameObject.SetActive(false);
        retry.SetActive(true);
    }
}
