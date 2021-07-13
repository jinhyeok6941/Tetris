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
    public GameObject [] tetris;    //예약 테트리스 모음

    public GameObject obstacleFactory;
    public List<GameObject> creatOst = new List<GameObject>();
    public List<GameObject> destOst = new List<GameObject>();
    int ostCnt = 191;
    public int obIndex = 0;         //장애물 참조 인덱스
    public int maxY;        //테트리스 좌표의 최대 높이 값
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
        bestScore.text = "SCOЯE : " + compareScore.ToString();
        SetOnTetris();
        //CreateObstacle();
        nowGrade = SceneManager.GetActiveScene().buildIndex;  //씬의 인덱스 값 받기.
        grade.text = "Grade : " + nowGrade.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        textTime.text = "TIME : " + ((int)time).ToString();
        score.text = "SCOЯE : " + scoreCount.ToString();
        line.text = "LINE : " + (scoreCount / 5).ToString();
        if (compareScore <= scoreCount)
        {
            compareScore = scoreCount;
            PlayerPrefs.SetInt("BS", compareScore);
            bestScore.text = "SCOЯE : " + compareScore.ToString(); 
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
        for (int i = 0; i < ostCnt; i++)         //장애물 객체 생성
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
