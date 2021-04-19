using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    public void OnClickRetry()
    {

        SceneManager.LoadScene(1);
    }
    public void OnclickStart()
    {
        SceneManager.LoadScene("MYKScene");
    }
}
