using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEngine : MonoBehaviour
{
    public AudioSource[] bgm;
    public float timeForMusicToFadeOut = 2f;

    public static SoundEngine instance;

    void Start()
    {
        instance = this;
    }

    public void PlaySFX(AudioSource sfx)
    {
        sfx.Play();
    }

    public void UpdateMusic(AudioSource[] musicTracks, float timeToFadeIn, int maxVolume)
    {
        StopMusic();//Stop music that is already playing
        PlayMusic(musicTracks, timeToFadeIn, maxVolume);//Start to play new music
    }


    public void PlayMusic(AudioSource[] musicTracks, float timeToFadeIn, int maxVolume)
    {
        foreach(AudioSource track in musicTracks)
        {
            StartCoroutine(FadeIn(track, timeToFadeIn, maxVolume));
        }
    }

    public void StopMusic()
    {
        foreach(AudioSource musicTrack in bgm)
        {
            if(musicTrack.isPlaying)
            {
                StartCoroutine(FadeOut(musicTrack, timeForMusicToFadeOut));
            }
        }
    }

    public IEnumerator FadeIn(AudioSource audioSource, float FadeTime, int musicVolume)
    {
        audioSource.volume = 0;
        audioSource.Play();
        while (audioSource.volume < musicVolume)
        {
            audioSource.volume += Time.deltaTime / FadeTime;

            yield return null;
        }
    }

    public IEnumerator FadeOut(AudioSource audioSource, float FadeTime)
    {
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / FadeTime;

            yield return null;
        }

        audioSource.Stop();
        audioSource.volume = startVolume;
    }
}
