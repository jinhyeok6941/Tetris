using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float currtime;      //1�� ���� �� ĭ�� �Ʒ��� ��������
    float checktime; 
    public static int height = 24;
    public static int width = 10;
    static int y;
    int rand, checkinttime = 1;
    private static Transform[,] grid = new Transform[width, height];

    public GameObject[] tetris;
    GameObject reObj;
    Reserve re;
    int randY;       //��ֹ� �����Ǵ� ���� ��

    // Start is called before the first frame update
    void Start()
    {
        reObj = GameObject.Find("ReserveTetris");
        re = reObj.GetComponent<Reserve>();
        randY = Random.Range(1, re.checktime/3);          //1 ~ 3 ���� ������ ����
    }

    // Update is called once per frame
    void Update()
    {
        checktime += Time.deltaTime;        //�������� �ӵ� �� üũ��
        currtime = re.currtime;             //�ð��� ���� �ӵ� ��ȭ��
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
                transform.position += new Vector3(0, 1, 0);
        }
        if (currtime < checktime)
        { 
              transform.position += Vector3.down;
              checktime = 0;  
        }

        if (!MovingRange())      //��Ʈ���� ������Ʈ�� �̵� �Ұ� ������ ��
        {
            transform.position -= Vector3.down;
            re.SetOffTetris();
            CreateTetris();
            this.enabled = false;    //��ũ��Ʈ ��Ȱ��ȭ
            AddtoGrid();
            Check_Line();
            int randob = Random.RandomRange(1, 16 - re.checktime);     //15�ܰ� �޼��� ��
            if(randob<4)
            AddObstacle();          //��ֹ� ����
        }
    }
    void CreateTetris()
    {
            if (!grid[1,18] && !grid[4, 18] && !grid[7, 18] && !grid[9, 18])
            {
                GameObject tetrisObject = Instantiate(tetris[re.rand]);
                re.SetOnTetris();  //rand ���� ���� ������
                tetrisObject.transform.position = new Vector3(4, 18, 0);
            }
            else
            {
                re.Retry();
            }
    }
    void AddtoGrid()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            int positionX = Mathf.RoundToInt(transform.GetChild(i).position.x);
            int positionY = Mathf.RoundToInt(transform.GetChild(i).position.y);
            grid[positionX, positionY] = transform.GetChild(i);
            if (positionY >= re.maxY)              //Y �� Ž�� �ִ�ġ ����.
                re.maxY = positionY;
        }
    }

    bool MovingRange()    //�̵� ���� ����
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

    void Check_Line()       //y �� �������� �� Ž��
    {
             int y = re.maxY;
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
                    re.maxY--;           //������ ��ġ��ŭ Y�� �ִ� Ž�� ���� ���̳ʽ�. 
                 }
                y--;
              }
    }
    void Drop_Line(int destroy)       //������ �� ���� ���ϵ� 1ĭ ������
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
                if (grid[x, y].gameObject.name.Contains("Obstacle"))
                {
                    re.obIndex--;                                  //��ֹ� ���� �� ����Ʈ�� �������� false�� �ɶ����� -�Ѵ�.
                    grid[x, y].gameObject.SetActive(false);
                    re.destOst.Add(grid[x, y].gameObject);         //��Ȱ��ȭ�� ��ֹ� ���
                    re.creatOst.RemoveAt(re.obIndex);
                }
                else
                    Destroy(grid[x, y].gameObject);                //��Ʈ���� ������Ʈ�� ��� ����.
                    grid[x, y] = null;                             //��Ȱ��ȭ �Ǵ� ���� �� grid���� nulló��.
              }
            }
        re.scoreCount+=5;
    }

    void AddObstacle()        //��ֹ� �߰��ϱ�.
    {
        for (int y = re.maxY+3; y >= 0; y--)      //���� �� �� ĭ�� �ø���.  re.maxY�� ���� maxY���� �������� �ִ� ������ 4�̱� ����.
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
        for (int y = randY-1; y > -1; y--)          //�� �� ���� ó�� �ε������� ���� ��Ȱ��ȭ �迭�� �ѱ� �� �ε����� �������� �մ����
        {
            for (int x = 0; x < width; x++)
            {
                if (x == rand1) continue;           //������ ���� ��ֹ� ��������
                if (re.destOst.Count > 0)           //��Ȱ�� ��ֹ��� 1�� �̻��� �� ���� 
                {
                    re.creatOst.Add(re.destOst[0]); //Ȱ��ȭ ��ֹ��� ��Ȱ��ȭ�� �������� ���¿��� �����ϸ� ������. 
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