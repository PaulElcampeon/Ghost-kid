using System.Collections;
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
    public bool loadEndScene;
    public GameObject menuObject;
    public GameObject menu;
    public GameObject gameOverScreen;

    public Floor[] floors;
    public Slider fearLevelBar;

    public static GameManager instance;


    void Start()
    {
        instance = this;
        //ScreenFade.instance.FadeFromBlack();
    }

    void Update()
    {
        if(Input.anyKey && gameOverScreen.activeInHierarchy)
        {
            ScreenFade.instance.FadeToBlack();
            StartCoroutine(LoadMainMenu(3f));
        }

        if (Input.GetKeyDown(KeyCode.Escape) && !gameOverScreen.activeInHierarchy)
        {
            if (gamePaused)
            {
                SoundEngine.instance.PlayPauseSound();
                Resume();
            } else
            {
                SoundEngine.instance.PlayPauseSound();
                menu.SetActive(true);
                Pause();
            }
        }

       if(isDead && !gameOverScreen.activeInHierarchy)
       {
            isDead = false;
            StartCoroutine(ShowGameOverScreen());
       }

       if (allMissionsComplete)
        {
            PriestManager.instance.DeactivateAllPriests();
            StartCoroutine(FadeScreenLate());
            StartCoroutine(LoadEndScene(15f));
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
        }
    }

    public void DecreaseFreakOMeter()
    {
        if (fearLevel > 0 && !hasMaxFearLevelBeenReached)
        {
            fearLevel--;
        }

        UpdateFreakOMeter();
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
        menuObject.GetComponent<InGameMenu>().CloseMenu();
        gamePaused = false;
        Time.timeScale = 1;
    }

    public void GameOver()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }

    public void CompleteAMission(int floorId)
    {
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
            if (!floor.isMissionComplete)
            {
                allMissionsComplete = false;
            }
        }

        if (allMissionsComplete)
        {
            loadEndScene = true;
        }
    }

    public IEnumerator LoadMainMenu(float timeInSeconds)
    {
        yield return new WaitForSeconds(timeInSeconds);
        GameOver();
    }

    public IEnumerator LoadEndScene(float timeInSeconds)
    {
        yield return new WaitForSeconds(timeInSeconds);
        SceneManager.LoadScene("End");
    }

    public IEnumerator FadeScreenLate()
    {
        yield return new WaitForSeconds(11f);
        ScreenFade.instance.FadeToBlack();
    }

    public IEnumerator FadeScreenLate(float timeInSeconds)
    {
        yield return new WaitForSeconds(timeInSeconds);
        ScreenFade.instance.FadeToBlack();
    }

    public IEnumerator ShowGameOverScreen()
    {
        ScreenFade.instance.FadeToBlack();
        yield return new WaitForSeconds(2f);
        gameOverScreen.SetActive(true);
        ScreenFade.instance.FadeFromBlack();
    }
}
