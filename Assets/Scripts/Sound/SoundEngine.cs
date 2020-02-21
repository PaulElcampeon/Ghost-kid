using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEngine : MonoBehaviour
{
    public AudioSource[] bgm;
    public AudioSource[] sfx;
    public float timeForMusicToFadeOut = 1f;
    public bool hasPriestSpawned;
    public float sfxVolume = 0.7f;
    public float bgmVolume = 0.5f;

    public static SoundEngine instance;

    void Start()
    {
        instance = this;
    }

    public void PlaySFX(AudioSource sfx)
    {
        sfx.volume = sfxVolume;
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
            audioSource.volume = 0;
            audioSource.Play();
            while (audioSource.volume < bgmVolume)
            {
                audioSource.volume += Time.deltaTime / FadeTime;
                yield return null;
            }
        }
    }

    public IEnumerator FadeOut(AudioSource audioSource)
    {
        float startVolume = bgmVolume;

        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / timeForMusicToFadeOut;
            yield return null;
        }

        audioSource.volume = 0;
        audioSource.Stop();
    }

    public void PlayPriestMusic(AudioSource[] music, float fadeIn, float maxVolume)
    {
        StopAllMusic();
        StartCoroutine(FadeIn(music[0], fadeIn, maxVolume));
        hasPriestSpawned = true;
    }

    public void PlayPauseSound()
    {
        foreach(AudioSource source in sfx)
        {
            if(source.name == "Pause Sound")
            {
                source.volume = sfxVolume;
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
                source.volume = sfxVolume;
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
                PlaySFX(source);
            }
        }
    }

    public void PlayItemDropSound()
    {
        foreach (AudioSource source in sfx)
        {
            if (source.name == "Item Drop sound")
            {
                PlaySFX(source);
            }
        }
    }

    public void PlayMusic(AudioSource music)
    {
        music.volume = bgmVolume;
        music.Play();
    }

    //This means that when we update the sound volume it will result in the current music volume not being updated until the player goes to another floor and a new peice of music begins to play with the new volume setting
    //The sound effects should take immediate effect as we set the volume when the effect is about to be played
    public void UpdateSoundVolume( float sfxVolume, float bgmVolume)
    {
        SoundEngine.instance.sfxVolume = sfxVolume;
        SoundEngine.instance.bgmVolume = bgmVolume;
    }
}
