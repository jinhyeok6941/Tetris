using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploEft : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //��ƼŬ �÷���
        ParticleSystem ps = GetComponent<ParticleSystem>();
        ps.Play();
        //���� �÷���
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
