using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    // Start is called before the first frame update
    public enum BGM_TYPE
    {
        BGM_1,
        BGM_2,
        BGM_3,
        BGM_4
    }
    private void Start()
    {
        instance = this;
    }

    //BGM 담당 AudioSource
    public AudioSource bgmAudio;
    //EFT 당담 AudioSource


    //bgm 파일
    public AudioClip[] bgms;
    //eft 파일

    public void PlayBGM(BGM_TYPE type)
    {
        bgmAudio.clip = bgms[(int)type];
        bgmAudio.Play();
    }

}
