using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMManager : MonoBehaviour
{

    public static BGMManager instance;
    // Start is called before the first frame update


    public enum BGM_TYPE
    {
        BGM_4,
        BGM_5,
        BGM_6,
        BGM_7
    }

    //BGM 담당 AudioSource
    public AudioSource bgmAudio;
    //EFT 당담 AudioSource


    //bgm 파일
    public AudioClip[] bgms;


    void Start()
    {
        instance = this;
        int index = (SceneManager.GetActiveScene().buildIndex - 1);
      
        bgmAudio.clip = bgms[index];  //테트리스 단계별 배경 음악.
        bgmAudio.Play();
    }
    public void PlayBGM(BGM_TYPE type)
    {
        bgmAudio.clip = bgms[(int)type];
        bgmAudio.Play();
    }


}
