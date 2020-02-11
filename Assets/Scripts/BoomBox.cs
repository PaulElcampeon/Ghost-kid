using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomBox : MonoBehaviour
{
    public bool isPlayerPresent;
    public AudioSource track;
    public bool isAlreadyPlaying;
    public static BoomBox instance;

    public void Start()
    {
        instance = this;
    }

    void Update()
    {
       if(isPlayerPresent && !isAlreadyPlaying && !SoundEngine.instance.hasPriestSpawned)
        {
            isAlreadyPlaying = true;
            SoundEngine.instance.PlayMusic(track);
        }

        if(!isPlayerPresent)
        {
            track.Stop();
            isAlreadyPlaying = false;
        } 
    }
}
