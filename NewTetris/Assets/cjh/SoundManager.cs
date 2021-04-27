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

    public enum EFT_TYPE
    {
        BGM_4,
        BGM_5,
        BGM_6
    }

    //BGM ��� AudioSource
    public AudioSource bgmAudio;
    //EFT ��� AudioSource
    public AudioSource eftAudio;

    //bgm ����
    public AudioClip[] bgms;
    //eft ����
    public AudioClip[] gradebgm;

    void Start()
    {
        instance = this;
        print("ddd : " + (SceneManager.GetActiveScene().buildIndex - 1));
        int index = SceneManager.GetActiveScene().buildIndex - 1;
        eftAudio.clip = gradebgm[index];  //��Ʈ���� �ܰ躰 ��� ����.
        eftAudio.Play();
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
