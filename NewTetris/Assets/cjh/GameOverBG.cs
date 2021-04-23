using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  //Scene ÂüÁ¶

public class GameOverBG : MonoBehaviour
{
    public void OnClickRetry()
    {
        SceneManager.LoadScene(0);
    }
}
