using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploEft : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //파티클 플레이
        ParticleSystem ps = GetComponent<ParticleSystem>();
        ps.Play();
        //사운드 플레이
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
