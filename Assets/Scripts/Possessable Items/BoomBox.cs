using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomBox : MonoBehaviour
{
    public AudioSource track;
    public AudioClip[] audioClipArray;
    public bool isAlreadyPlaying;
    public static BoomBox instance;
    public Animator animator;
    public Possessed possessedScript;

    public void Start()
    {
        instance = this;
        possessedScript = gameObject.GetComponent<Possessed>();
    }

    public void Update()
    {        
       if(possessedScript.isPlayerPresent && !isAlreadyPlaying && !SoundEngine.instance.hasPriestSpawned)
        {
            track.clip = audioClipArray[Random.Range (0, audioClipArray.Length)];
            isAlreadyPlaying = true;
            animator.SetBool("isPlaying", true);
            track.volume = 0.99f;
            track.Play();
        }

        if(!possessedScript.isPlayerPresent)
        {
            track.Stop();
            isAlreadyPlaying = false;
            animator.SetBool("isPlaying", false);
        } 
    }
}
