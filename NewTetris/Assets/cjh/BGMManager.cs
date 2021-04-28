using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMManager : MonoBehaviour
{
    

    // Start is called before the first frame update
    

    public enum EFT_TYPE
    {
        BGM_4,
        BGM_5,
        BGM_6
    }

    //BGM ��� AudioSource
    public AudioSource bgmAudio;
    //EFT ��� AudioSource


    //bgm ����
    public AudioClip[] bgms;


    void Start()
    {
        
        int index = (SceneManager.GetActiveScene().buildIndex - 1);
      
        bgmAudio.clip = bgms[index];  //��Ʈ���� �ܰ躰 ��� ����.
        bgmAudio.Play();
    }

 

}
