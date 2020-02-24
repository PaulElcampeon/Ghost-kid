using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomBox : Possessed
{
    //public bool isPlayerPresent;
    public AudioSource track;
    public AudioClip[] audioClipArray;
    public bool isAlreadyPlaying;
    public static BoomBox instance;
    public Animator animator;

    public void Start()
    {
        instance = this;
    }

    public override void Update()
    {
        base.Update();
        
       if(isPlayerPresent && !isAlreadyPlaying && !SoundEngine.instance.hasPriestSpawned)
        {
            track.clip = audioClipArray[Random.Range (0, audioClipArray.Length)];
            isAlreadyPlaying = true;
            animator.SetBool("isPlaying", true);
            SoundEngine.instance.PlayMusic(track);
        }

        if(!isPlayerPresent)
        {
            track.Stop();
            isAlreadyPlaying = false;
            animator.SetBool("isPlaying", false);

        } 
    }
}
