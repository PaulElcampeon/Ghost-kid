﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelIntro : MonoBehaviour
{
    public GameObject panel;
    public float delay;
    public bool hasPlayed;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && panel.activeInHierarchy)
        {
            panel.SetActive(false);
            GameManager.instance.Resume();
        }

        //NOT USING THIS AS WE ARE ALLOWING THE PLAYER TO CANCEL THE PANEL BY HITTING THE SPACE KEY
        //FadeOutPanelAndResumeGame();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {

        if ((other.gameObject.CompareTag("Player") || (other.gameObject.CompareTag("Possessable") && other.gameObject.GetComponent<Possessed>().isPlayerPresent)) && !hasPlayed)
        {
            panel.SetActive(true);
            hasPlayed = true;

            GameManager.instance.Pause();
        }
    }

    public void FadeOutPanelAndResumeGame()
    {
       if (panel.activeInHierarchy)
       {
           delay -= Time.deltaTime;

           if (delay <= 0)
           {
               panel.SetActive(false);
               GameManager.instance.Resume();
           }
       }
    }
}
