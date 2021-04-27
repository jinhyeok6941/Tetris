using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public enum EFT_TYPE
    {
        EFT_1,
        EFT_2,
        EFT_3
    }

    //BGM ��� AudioSource
    public AudioSource bgmAudio;
    //EFT ��� AudioSource
    public AudioSource eftAudio;

    //bgm ����
    public AudioClip[] bgms;
    //eft ����
    public AudioClip[] efts;

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

    public void PlayEFT(EFT_TYPE type)
    {
        eftAudio.clip = efts[(int)type];
        eftAudio.Play();
        eftAudio.PlayOneShot(efts[(int)type]); //ȿ���� ���� ���� ����.���� ȿ������ ����ǵ� ������� �����.
    }
}
