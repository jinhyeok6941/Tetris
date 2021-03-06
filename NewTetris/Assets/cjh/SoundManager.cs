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
        BGM_3
    }

    //BGM 담당 AudioSource
    public AudioSource bgmAudio;
    //EFT 당담 AudioSource

    //bgm 파일
    public AudioClip[] bgms;
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayBGM(BGM_TYPE type)
    {
        bgmAudio.clip = bgms[(int)type];
        bgmAudio.Play();
    }

}
