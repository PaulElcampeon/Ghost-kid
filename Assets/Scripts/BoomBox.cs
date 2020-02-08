using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomBox : MonoBehaviour
{
    public bool isPlayerPresent;
    public AudioSource track;
    public bool isAlreadyPlaying;

    void Update()
    {
       if(isPlayerPresent && !isAlreadyPlaying)
        {
            isAlreadyPlaying = true;
            track.Play();
        }

        if(!isPlayerPresent)
        {
            track.Stop();
            isAlreadyPlaying = false;
        } 
    }
}
