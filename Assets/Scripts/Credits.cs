using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
    public GameObject player;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = player.GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            LoadMenu();
        }
    }

    public IEnumerator FadeOutMusic(float timeInSeconds)
    {
        float startVolume = 0.15f;

        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / timeInSeconds;
            yield return null;
        }

    }

    private void LoadMenu()
    {
        StartCoroutine(GameManager.instance.FadeScreenLate(4f));
        StartCoroutine(GameManager.instance.LoadMainMenu(6f));
        //StartCoroutine(FadeOutMusic(4f));
    }
}
