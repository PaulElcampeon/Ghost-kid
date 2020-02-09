using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour
{
    public AudioSource[] bgmTrack;
    private List<Coroutine> coroutines = new List<Coroutine>();
    public float timeToFadeIn;
    public float maxVolume;
    public bool isMusicPlaying;
    public bool stayed;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Music Detection") || (other.gameObject.CompareTag("Possessable") && other.gameObject.GetComponent<Possessed>().isPlayerPresent) || (other.gameObject.CompareTag("Hideable") && other.gameObject.GetComponent<Hideable>().isOccupied))
        {
            Debug.Log("Player just Entered");

            if (coroutines.Count > 0)
            {
                foreach (Coroutine routine in coroutines)
                {
                    if (routine != null)
                    {
                        StopCoroutine(routine);
                    }
                }
                coroutines.Clear();
            }
            if (!isMusicPlaying)
            {
                foreach (AudioSource track in bgmTrack)
                {
                    coroutines.Add(StartCoroutine(SoundEngine.instance.FadeIn(track, timeToFadeIn, maxVolume)));
                    isMusicPlaying = true;
                }
            }
        }
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Music Detection") || (other.gameObject.CompareTag("Possessable") && other.gameObject.GetComponent<Possessed>().isPlayerPresent) || (other.gameObject.CompareTag("Hideable") && other.gameObject.GetComponent<Hideable>().isOccupied))
        {
            
            foreach (AudioSource track in bgmTrack)
            {
                if (!track.isPlaying)
                {
                    coroutines.Add(StartCoroutine(SoundEngine.instance.FadeIn(track, timeToFadeIn, maxVolume)));
                }
            }
            isMusicPlaying = true;
            
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (!GetComponent<BoxCollider2D>().bounds.Contains(Player.instance.transform.position))
        {
            Debug.Log("Player just exited");
            isMusicPlaying = false;
            stayed = false;

            if (coroutines.Count > 0)
            {
                foreach (Coroutine routine in coroutines)
                {
                    if (routine != null)
                    {
                        StopCoroutine(routine);
                    }
                }
            }

            coroutines.Clear();

            foreach(AudioSource track in bgmTrack)
            {
                coroutines.Add(StartCoroutine(SoundEngine.instance.FadeOut(track)));
            }
        }
    }
}
