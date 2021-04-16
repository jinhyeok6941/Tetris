using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float currtime = 1;      //1�� ���� �� ĭ�� �Ʒ��� ��������
    float checktime;
    //float attacktime,checkattack;
    public static int height = 20;
    public static int width = 10;
    static int y;
    int rand;  
    private static Transform[,] grid = new Transform[width, height];
  
    public GameObject[] tetris;
    GameObject reObj;
    Reserve re;

    // Start is called before the first frame update
    void Start()
    {
        reObj = GameObject.Find("ReserveTetris");
        re = reObj.GetComponent<Reserve>();
        //int rand = Random.Range(0,5);
        //GameObject tetrisObject = Instantiate(tetris[rand]);
        //tetrisObject.transform.position = new Vector3(4.25f, 15, 0);
    }

    // Update is called once per frame
    void Update()
    {
    //    attacktime+= Time.deltaTime;
        checktime += Time.deltaTime;
        // ��Ʈ���� ��ü ������ ����
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
              transform.position += Vector3.down;
              checktime = 0;  
        }
        //if (attacktime / 100 > checkattack && currtime > 0.3f)    //��Ʈ������ ������ ������ ��ŸŸ���� �ʱ�ȭ
        //{
        //    print("�ӵ� ����");
        //    currtime -= 0.2f;
        //    checkattack = attacktime / 100;
        //}

        if (!MovingRange())      //��Ʈ���� ������Ʈ�� �̵� �Ұ� ������ ��
        {
            transform.position -= Vector3.down;
            re.SetOffTetris();
            CreateTetris();
            this.enabled = false;    //��ũ��Ʈ ��Ȱ��ȭ
            AddtoGrid();
            Check_Line();
        }
    }
    void CreateTetris()
    {
        GameObject tetrisObject = Instantiate(tetris[re.rand]);
        re.SetOnTetris();  //rand ���� ���� ������
        tetrisObject.transform.position = new Vector3(4.25f, 15, 0);
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

    bool MovingRange()    //�̵� ���� ����
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

    void Check_Line()       //y �� �������� �� Ž��
    {
             int y = height-1;
             while(y > -1)       //2���� �迭 Ž��
             {
                int x = 0;
                while (x<width)
                 {
                    if (!grid[x, y])   //grid[x,y]�� ���� false ��� Ż��
                        break;
                    x++;
                 }
                 if (x == width)
                 {
                    Destroy_Line(y);
                    Drop_Line(y+1);   //������ �� y�� ���� y�� �ѱ��.
                 }
                y--;
              }
    }
    void Drop_Line(int destroy)       //������ �� ���� ��ϵ� 1ĭ ������
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
    void Destroy_Line(int y)     //���� �� �����
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
