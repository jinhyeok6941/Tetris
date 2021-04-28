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

    //BGM ��� AudioSource
    public AudioSource bgmAudio;
    //EFT ��� AudioSource


    //bgm ����
    public AudioClip[] bgms;


    void Start()
    {
        instance = this;
        int index = (SceneManager.GetActiveScene().buildIndex - 1);
      
        bgmAudio.clip = bgms[index];  //��Ʈ���� �ܰ躰 ��� ����.
        bgmAudio.Play();
    }
    public void PlayBGM(BGM_TYPE type)
    {
        bgmAudio.clip = bgms[(int)type];
        bgmAudio.Play();
    }


}
