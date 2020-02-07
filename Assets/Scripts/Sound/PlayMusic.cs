using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour
{
    public AudioSource[] bgm;
    public float timeToFadeIn;
    public int maxVolume;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Damnit");
            SoundEngine.instance.UpdateMusic(bgm, timeToFadeIn, maxVolume);
        } 
    }
}
