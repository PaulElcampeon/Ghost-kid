using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEngine : MonoBehaviour
{
    public AudioSource[] bgm;
    public AudioSource[] sfx;
    public float timeForMusicToFadeOut = 1f;
    public bool hasPriestSpawned;

    public static SoundEngine instance;

    void Start()
    {
        instance = this;
    }

    public void PlaySFX(AudioSource sfx)
    {
        sfx.Play();
    }

    public void StopAllMusic()
    {
        foreach (AudioSource track in bgm)
        {
            track.Stop();
        }
    }

    public IEnumerator FadeIn(AudioSource audioSource, float FadeTime, float musicVolume)
    {
        if (!hasPriestSpawned)
        {
            audioSource.Play();
            while (audioSource.volume < musicVolume)
            {
                audioSource.volume += Time.deltaTime / FadeTime;
                Debug.Log("Still trying to fade in " + audioSource.name);
                yield return null;
            }
        }
    }

    public IEnumerator FadeOut(AudioSource audioSource)
    {
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / timeForMusicToFadeOut;
            Debug.Log("Still trying to fade out " + audioSource.name);

            yield return null;
        }

        audioSource.Stop();
    }

    public void PlayPriestMusic(AudioSource[] music, float fadeIn, float maxVolume)
    {
        StopAllMusic();//Stop music that is already playing
        StartCoroutine(FadeIn(music[0], fadeIn, maxVolume));
        hasPriestSpawned = true;
    }

    public void PlayPauseSound()
    {
        foreach(AudioSource source in sfx)
        {
            if(source.name == "Pause Sound")
            {
                source.Play();
            }
        }
    }

    public void PlayExitSound()
    {
        foreach (AudioSource source in sfx)
        {
            if (source.name == "Exit Sound")
            {
                source.Play();
            }
        }
    }

    public void PlayPlaySound()
    {
        foreach (AudioSource source in sfx)
        {
            if (source.name == "Play Sound")
            {
                source.Play();
            }
        }
    }

    public void PlayItemDropSound()
    {
        foreach (AudioSource source in sfx)
        {
            if (source.name == "Item Drop sound")
            {
                source.Play();
            }
        }
    }
}
