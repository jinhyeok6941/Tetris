using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reserve : MonoBehaviour
{
    public float time,currtime = 1;
    public int checktime;
    public Text score;
    public Text grade;
    public Text textTime;
    public Text line;
    public int scoreCount = 0;
    public GameObject [] tetris;    //���� ��Ʈ���� ����

    public GameObject obstacleFactory;
    public List<GameObject> creatOst = new List<GameObject>();
    public List<GameObject> destOst = new List<GameObject>();
    int ostCnt = 90;
    public int obIndex = 0;         //��ֹ� ���� �ε���
    public int maxY;        //��Ʈ���� ��ǥ�� �ִ� ���� ��
    public GameObject retry;
    //public static Reserve re;
    // Start is called before the first frame update
    //private void Awake()
    //{
    //    re = this;
    //}
    public int rand;
    void Start()
    {
        SetOnTetris();
        CreateObstacle();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        textTime.text = "Time : " + ((int)time).ToString();
        if (scoreCount/15 > checktime)                      //���ھ� 25���� GRADE �ܰ� �� �� �ӵ� ����
        {   
            currtime -= 0.1f;
            checktime++;
            grade.text = "Grade : " + checktime.ToString();
        }
        score.text = "Score : " + scoreCount.ToString();
        line.text = "Line : " + (scoreCount / 5).ToString();
    }

    public void SetOnTetris()
    {
        rand = Random.Range(0, 7);
        tetris[rand].SetActive(true);
    }

    public void SetOffTetris()
    {
        tetris[rand].SetActive(false);
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
