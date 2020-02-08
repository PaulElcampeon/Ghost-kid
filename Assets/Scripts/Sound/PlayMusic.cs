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

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Music Detection") || (other.gameObject.CompareTag("Possessable") && other.gameObject.GetComponent<Possessed>().isPlayerPresent))
        {
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

    public void OnTriggerExit2D(Collider2D other)
    {
        if (!GetComponent<BoxCollider2D>().bounds.Contains(Player.instance.GetComponent<Rigidbody2D>().transform.position))
        {
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
                isMusicPlaying = false;
            }
        }
    }
}
