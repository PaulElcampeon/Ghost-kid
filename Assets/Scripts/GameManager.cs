﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float fearLevel;
    public float fearLevelMax;
    public bool gameEnded;
    public bool gamePaused;
    public bool isPossessing;
    public bool isHiding;
    public bool isDead;
    public bool allMissionsComplete;
    public bool canMove = true;
    public bool allMoved = true;
    public bool hasMaxFearLevelBeenReached;

    public Floor[] floors;
    public Slider fearLevelBar;

    public static GameManager instance;


    void Start()
    {
        instance = this;
        ScreenFade.instance.FadeFromBlack();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamePaused)
            {
                Resume();

            } else
            {
                Pause();
            }
        }

       if(isDead)
       {
            isDead = false;
            Debug.Log("You are dead");
            ScreenFade.instance.FadeToBlack();
            StartCoroutine(LoadMainMenuQuick());
       }

       if (allMissionsComplete)
        {
            //Debug.Log("All Missions Completed");
            PriestManager.instance.DeactivateAllPriests();
            StartCoroutine(FadeScreenLate());
            StartCoroutine(LoadMainMenuSlow());
        }
    }

    public void IncreaseFreakOMeter()
    {
        if(fearLevel < fearLevelMax)
        {
            fearLevel++;

            if(fearLevel == fearLevelMax)
            {
                hasMaxFearLevelBeenReached = true;
                PriestManager.instance.Spawn();
            }
            UpdateFreakOMeter();
            Debug.Log("Increased Freak O Meter");
        }
    }

    public void DecreaseFreakOMeter()
    {
        if (fearLevel > 0 && !hasMaxFearLevelBeenReached)
        {
            fearLevel--;
        }

        UpdateFreakOMeter();
        Debug.Log("Decreased Freak O Meter");
    }

    public void UpdateFreakOMeter()
    {
        fearLevelBar.maxValue = fearLevelMax;
        fearLevelBar.value = fearLevel;
    }

    public void Pause()
    {
        gamePaused = true;
        Time.timeScale = 0;
    }

    public void Resume()
    {
        gamePaused = false;
        Time.timeScale = 1;
    }

    public void GameOver()
    {
        SceneManager.LoadScene("Menu");
    }

    public void CompleteAMission(int floorId)
    {
        Debug.Log("Someone just completed a mission");
        foreach(Floor floor in floors)
        {
            if(floor.floorId == floorId)
            {
                floor.isMissionComplete = true;
                DecreaseFreakOMeter();
            }
        }
        UpdateAllMissionsCompleted();
    }


    public void UpdateAllMissionsCompleted()
    {
        allMissionsComplete = true;

        foreach (Floor floor in floors)
        {
            if(!floor.isMissionComplete)
            {
                allMissionsComplete = false;
            }
        }

        if(allMissionsComplete)
        {
            gameEnded = true;
        }
    }


    public IEnumerator LoadMainMenuQuick()
    {
        yield return new WaitForSeconds(4f);
        GameOver();
    }

    public IEnumerator LoadMainMenuSlow()
    {
        yield return new WaitForSeconds(15f);
        GameOver();
    }

    public IEnumerator FadeScreenLate()
    {
        yield return new WaitForSeconds(11f);
        ScreenFade.instance.FadeToBlack();

    } 

    /*public void MoveAllCharactersToRightSideOfHouse()
    {
        allMoved = true;
        for(int i = 0; i < npcs.Length; i++)
        {
            Vector2 newPosition = Vector2.MoveTowards(npcs[i].transform.position, new Vector2(20.58f, npcs[i].transform.position.y), 2f * Time.deltaTime);
            npcs[i].GetComponent<Rigidbody2D>().MovePosition(newPosition);

            if (npcs[i].transform.position.x != 20.58f)
            {
                allMoved = false;
            } 
        }
    }*/
}
