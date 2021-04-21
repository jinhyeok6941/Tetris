using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float currtime;      //1초 마다 한 칸씩 아래로 떨어지게
    float checktime;
    //float attacktime,checkattack;
    public static int height = 20;
    public static int width = 10;
    static int y;
    int rand,checkinttime = 1;  
    private static Transform[,] grid = new Transform[width, height];
  
    public GameObject[] tetris;
    public GameObject obstacle;
    GameObject reObj;
    Reserve re;

    // Start is called before the first frame update
    void Start()
    {
        reObj = GameObject.Find("ReserveTetris");
        re = reObj.GetComponent<Reserve>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (currtime > re.currtime)
        //{
        //    AddObstacle();
        //}
        //if (re.time / 10 > checkinttime)
        //{
        //    print(re.time/10 + "    " + checkinttime);
        //    AddObstacle();
        //    checkinttime++;
        //}
        currtime = re.currtime;
        
        //print(re.time);
    //    attacktime+= Time.deltaTime;
        checktime += Time.deltaTime;
        // 테트리스 객체 움직임 구현
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left;
            if (!MovingRange())
                transform.position -= Vector3.left;

        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += Vector3.right;
            if (!MovingRange())
                transform.position -= Vector3.right;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.position += Vector3.down;
            if (!MovingRange())
                transform.position -= Vector3.down;
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.Rotate(0, 0, 90);
            if (!MovingRange())
                transform.Rotate(0, 0, -90);
        }
        else if (Input.GetKey(KeyCode.Z))
        {
            transform.position += new Vector3(0, -1, 0);
            if (!MovingRange())
                transform.position -= Vector3.down;
        }
        if (currtime < checktime) 
        {
            print(currtime);
              transform.position += Vector3.down;
              checktime = 0;  
        }
        //10초마다 속도가 0.2초씩 더 빨라지게 만들기.
        
        //if (attacktime / 100 > checkattack && currtime > 0.3f)    //테트리스가 생성될 때마다 델타타임이 초기화
        //{
        //    print("속도 증가");
        //    currtime -= 0.2f;
        //    checkattack = attacktime / 100;
        //}

        if (!MovingRange())      //테트리스 오브젝트가 이동 불가 상태일 때
        {
            transform.position -= Vector3.down;
            re.SetOffTetris();
            CreateTetris();
            this.enabled = false;    //스크립트 비활성화
            AddtoGrid();
            Check_Line();
        }
    }
    void CreateTetris()
    {
        if (!grid[5, 15])
        {
            GameObject tetrisObject = Instantiate(tetris[re.rand]);
            re.SetOnTetris();  //rand 값이 새로 설정됨
            tetrisObject.transform.position = new Vector3(4, 15, 0);
         }
    }
    void AddtoGrid()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            int positionX = Mathf.RoundToInt(transform.GetChild(i).position.x);
            int positionY = Mathf.RoundToInt(transform.GetChild(i).position.y);
            grid[positionX, positionY] = transform.GetChild(i);
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
            {
                return false;
            }
        }
        return true;
    }

    void Check_Line()       //y 축 기준으로 줄 탐색
    {
             int y = height-1;
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
                    Drop_Line(y+1);   //지워진 줄 y축 위의 y값 넘기기.
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
                Destroy(grid[x, y].gameObject);
                grid[x, y] = null;
               }
            }
        re.scoreCount++;
    }

    void AddObstacle()        //장애물 추가하기.
    {
        for (int y = height-2; y >= 0; y--)      //생성 전 한 칸씩 올리기.
        {
            for (int x = 0; x < width; x++)
            {
                if (grid[x, y])
                {
                    grid[x, y + 1] = grid[x, y];
                    grid[x, y].gameObject.transform.position += Vector3.up;
                    grid[x, y] = null;
                }
            }
        }

        int rand1 = Random.Range(0, 10);
        for (int x = 0; x < width; x++)
        {
            //리스트 10 * 20개의 상자만들고
            //호출 된 양만큼 생성하기.
            if (x == rand1)
                continue;
            GameObject ost = Instantiate(obstacle);
            ost.transform.position = new Vector3(x, 0, 0);
            grid[x, 0] = ost.transform.GetChild(0);
            
        }
    }
    void ResetTetris()
    {
        for (int y = height - 1; y > -1; y--)
        {
            for (int x = 0; x < width; x++)
            {
                if (grid[x, y])
                {
                    Destroy(grid[x, y].gameObject);
                    grid[x, y] = null;
                }
            }
        }
    }
}
