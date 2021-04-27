using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    float currtime;      //1초 마다 한 칸씩 아래로 떨어지게
    float checktime;
    public static int height = 24;
    public static int width = 10;
    static int y;
    int rand, checkinttime = 1;
    private static Transform[,] grid = new Transform[width, height];

    public GameObject[] tetris;
    public GameObject tetrisEffectFactory;
    GameObject reObj, gmMg;
    GameManager gm;
    Reserve re;
    int randY;       //장애물 생성되는 줄의 양

    // Start is called before the first frame update
    void Start()
    {
        gmMg = GameObject.Find("GameManager");
        gm = gmMg.GetComponent<GameManager>();
        reObj = GameObject.Find("ReserveTetris");
        re = reObj.GetComponent<Reserve>();
        randY = Random.Range(1, re.nowGrade/3);          //1 ~ 3 개의 생성량 지정
        this.enabled = true;
        currtime = 1 - (SceneManager.GetActiveScene().buildIndex * 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        checktime += Time.deltaTime;        //떨어지는 속도 비교 체크용
        // 테트리스 객체 움직임 구현
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            SoundManager.instance.PlayBGM(SoundManager.BGM_TYPE.BGM_1);
            transform.position += Vector3.left;
            if (!MovingRange())
                transform.position -= Vector3.left;

        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += Vector3.right;
            SoundManager.instance.PlayBGM(SoundManager.BGM_TYPE.BGM_1);
            if (!MovingRange())
                transform.position -= Vector3.right;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.position += Vector3.down;
            SoundManager.instance.PlayBGM(SoundManager.BGM_TYPE.BGM_1);
            if (!MovingRange())
                transform.position -= Vector3.down;
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            SoundManager.instance.PlayBGM(SoundManager.BGM_TYPE.BGM_1);
            transform.Rotate(0, 0, 90);
            if (!MovingRange())
            {
                transform.Rotate(0, 0, -90);
            }
        }
        else if (Input.GetKey(KeyCode.Z))
        {
            transform.position += new Vector3(0, -1, 0);
            if (!MovingRange())
                transform.position += new Vector3(0, 1, 0);
        }
        if (currtime < checktime)
        { 
              transform.position += Vector3.down;
              checktime = 0;  
        }

        if (!MovingRange())      //테트리스 오브젝트가 이동 불가 상태일 때
        {
            SoundManager.instance.PlayBGM(SoundManager.BGM_TYPE.BGM_2);
            transform.position -= Vector3.down;
            re.SetOffTetris();
            this.enabled = false;    //스크립트 비활성화
            CreateTetris();
            AddtoGrid();
            Check_Line();
            int randob = Random.RandomRange(1, 16 - re.nowGrade);     //15단계 달성시 끝
            if(randob<4)
            AddObstacle();          //장애물 생성
            if(SceneManager.GetActiveScene().buildIndex * 3 == re.scoreCount/5)
            StartCoroutine(GradeUp());        //GradeUp 조건 달성 시 레벨업 사운드 호출 후 씬 전환.
            
        }
    }
    IEnumerator GradeUp()
    {
        SoundManager.instance.PlayBGM(SoundManager.BGM_TYPE.BGM_4);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
        void CreateTetris()
    {
        if (CheckWidth() || SceneManager.GetActiveScene().buildIndex * 3 == re.scoreCount / 5)
         {
            gm.tetrisIndex++;
            gm.tetris1[gm.tetrisIndex].SetActive(true);
         }
         else
                re.Retry();
    }
    bool CheckWidth()
    {
        for(int i = 0; i < width; i++)
        {
            if (grid[i, 18])
                return false;
        }
        return true;
    }
    void AddtoGrid()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            int positionX = Mathf.RoundToInt(transform.GetChild(i).position.x);
            int positionY = Mathf.RoundToInt(transform.GetChild(i).position.y);
            grid[positionX, positionY] = transform.GetChild(i);
            if (positionY >= re.maxY)              //Y 축 탐색 최대치 설정.
                re.maxY = positionY;
        }
    }

    bool MovingRange()    //이동 가능 범위
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            int positionX = Mathf.RoundToInt(transform.GetChild(i).position.x);
            int positionY = Mathf.RoundToInt(transform.GetChild(i).position.y);
            if (positionX < 0 || positionX >= width || positionY < 0 || positionY >= height)
            {
                return false;
            }
            if (grid[positionX, positionY])
                return false;
        }
        return true;
    }

    void Check_Line()       //y 축 기준으로 줄 탐색
    {
             int y = re.maxY;
             while(y > -1)       //2차원 배열 탐색
             {
                int x = 0;
                while (x<width)
                 {
                    if (!grid[x, y])   //grid[x,y]의 값이 false 라면 탈출
                        break;
                    x++;
                 }
                 if (x == width)
                 {
                    Destroy_Line(y);
                    Drop_Line(y+1);      //지워진 줄 y축 위의 y값 넘기기.
                    re.maxY--;           //낮아진 위치만큼 Y의 최대 탐색 범위 마이너스. 
                 }
                y--;
              }
    }
    void Drop_Line(int destroy)       //지워진 줄 위의 블록들 1칸 내리기
    {
        for(int y = destroy; y < height ; y++)
        {
            for(int x = 0; x < width ; x++)
            {
                if (grid[x, y])
                {
                    grid[x, y - 1] = grid[x, y];
                    grid[x, y].gameObject.transform.position += Vector3.down;
                    grid[x, y] = null;
                }
            }
        }
    }
    void Destroy_Line(int y)     //가로 줄 지우기
    {
            for (int x = 0; x < width; x++)
            {
              if (grid[x, y])
              {
                if (grid[x, y].gameObject.name.Contains("Obstacle"))
                {
                    re.obIndex--;                                  //장애물 생성 시 리스트의 참조값이 false가 될때가지 -한다.
                    grid[x, y].gameObject.SetActive(false);
                    re.destOst.Add(grid[x, y].gameObject);         //비활성화된 장애물 담기
                    re.creatOst.RemoveAt(re.obIndex);
                }
                else
                    grid[x, y].gameObject.SetActive(false);

                GameObject tetrisEffect = Instantiate(tetrisEffectFactory);
                tetrisEffect.transform.position = grid[x, y].gameObject.transform.position;
                ParticleSystem ps = tetrisEffect.GetComponent<ParticleSystem>();
                ps.Play();
       
                grid[x, y] = null;                             //비활성화 또는 삭제 후 grid값들 null처리.     
              }
            }
        re.scoreCount+=5;
        SoundManager.instance.PlayBGM(SoundManager.BGM_TYPE.BGM_3);
    }

    void AddObstacle()        //장애물 추가하기.
    {
        for (int y = re.maxY+3; y >= 0; y--)      //생성 전 한 칸씩 올리기.  re.maxY는 기존 maxY에서 더해지는 최대 범위가 4이기 때문.
        {
            for (int x = 0; x < width; x++)
            {
                if (grid[x, y])
                {
                    grid[x, y + randY] = grid[x, y];
                    grid[x, y].gameObject.transform.position += new Vector3(0,randY,0);
                    grid[x, y] = null;
                }
            }
        }
        int rand1 = Random.Range(0, 10);
        for (int y = randY-1; y > -1; y--)          //맨 윗 줄이 처음 인덱스부터 들어가야 비활성화 배열로 넘길 때 인덱스를 기점으로 앞당겨짐
        {
            for (int x = 0; x < width; x++)
            {
                if (x == rand1) continue;           //지정된 줄은 장애물 생성안함
                if (re.destOst.Count > 0)           //비활성 장애물이 1개 이상일 때 실행 
                {
                    re.creatOst.Add(re.destOst[0]); //활성화 장애물이 비활성화가 되지않은 상태에서 참조하면 오류남. 
                    re.destOst.RemoveAt(0);
                }
                re.creatOst[re.obIndex].SetActive(true);
                re.creatOst[re.obIndex].transform.position = new Vector3(x, y, 0);
                grid[x, y] = re.creatOst[re.obIndex].transform;
                re.obIndex++;
            }
        }
    }
}
