using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAtive : MonoBehaviour
{
    GameObject gmMg;
    GameManager gm;
    Vector3 [] childPosition;

    void Start()
    {
        gmMg = GameObject.Find("GameManager");
        gm = gmMg.GetComponent<GameManager>();
        childPosition = new Vector3 [transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            int positionX = Mathf.RoundToInt(transform.GetChild(i).position.x);
            int positionY = Mathf.RoundToInt(transform.GetChild(i).position.y);
            childPosition[i] = transform.GetChild(i).position;
        }
    }
    // Update is called once per frame
    void Update()
    {
        int checkChild = 0;
        for(int i = 0; i < transform.childCount; i++)
        {
            int positionX = Mathf.RoundToInt(transform.GetChild(i).position.x);
            int positionY = Mathf.RoundToInt(transform.GetChild(i).position.y);
            if (transform.GetChild(i).gameObject.activeSelf)
                checkChild++;
        }
                                           //비활성여부 확인 후 리스트에 담기.
        if (checkChild == 0)
        {
            gm.tetris1.Add(gameObject);
            gm.Reserve.Add(gm.tetris1.IndexOf(gameObject));
            GameManager.gminstance.Reserve.RemoveAt(gm.tetris1.IndexOf(gameObject));
            Player pr = gm.tetris1[gm.tetris1.IndexOf(gameObject)].GetComponent<Player>();
            pr.enabled = true;
            LookChild();
            gameObject.SetActive(false);
            gm.tetris1.RemoveAt(gm.tetris1.IndexOf(gameObject));
            gm.tetrisIndex--;
        }
    }
    void LookChild()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            int positionX = Mathf.RoundToInt(transform.GetChild(i).position.x);
            int positionY = Mathf.RoundToInt(transform.GetChild(i).position.y);
            if (!transform.GetChild(i).gameObject.activeSelf)
                transform.GetChild(i).gameObject.SetActive(true);
            transform.GetChild(i).position = childPosition[i];         //처음 위치값 세팅.
        }
    }
}
