using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float currtime = 1;      //1초 마다 한 칸씩 아래로 떨어지게
    float checktime;
    public static int height = 20;
    public static int width = 11;
    static int y;
    private static Transform[,] grid = new Transform[width, height];
  
    public GameObject[] tetris = new GameObject[7];
 
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        checktime += Time.deltaTime;
       
        // 테트리스 객체 움직임 구현
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
                transform.position += Vector3.left;
            if(!MovingRange())
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
                if(!MovingRange())
                transform.Rotate(0, 0, -90);
        }
         else if (Input.GetKey(KeyCode.Z))
        {
            transform.position += new Vector3(0,-1,0);
            if (!MovingRange())
                transform.position -= Vector3.down;
        }

            if (currtime < checktime)
            {
               transform.position += Vector3.down;
               checktime = 0;
            }

        if (!MovingRange())      //테트리스 오브젝트가 이동 불가 상태일 때
        {
            transform.position -= Vector3.down;
            CreateTetris();
            this.enabled = false;    //스크립트 비활성화
            AddtoGrid();
            Check_Line();
        }
    }
    void CreateTetris()
    {
        int rand = Random.Range(0, 5);
        GameObject tetrisObject = Instantiate(tetris[rand]);
        
        tetrisObject.transform.position = new Vector3(5, 15, 0);
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
            if (positionX < 0 || positionX == width || positionY < 0 || positionY > height)
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
    }
}
