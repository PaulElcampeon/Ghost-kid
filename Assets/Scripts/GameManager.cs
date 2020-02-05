using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float fearLevel;
    public float fearLevelMax;
    public bool gameEnded;
    public bool gamePaused;
    public bool isPossessing;
    public bool isHiding;
    public bool canMove = true;
    public bool allMoved = true;

    public GameObject gameOverScreen;
    GameObject[] npcs;
    //public GameObject FearLevelBar;

    public static GameManager instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        npcs = GameObject.FindGameObjectsWithTag("NPC");
    }

    // Update is called once per frame
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


       /* if (fearLevel >= fearLevelMax)
        {
            gameEnded = true;

            if (gameEnded)
            {

            }
        }*/

       /* if (CheckIfAllMissionsCompleted())
        {
            MoveAllCharactersToRightSideOfHouse();

            if(allMoved)
            {
                Debug.Log("All Chars Moved");
            }
        }*/

    }

    public void IncreaseFearLevel(float amount)
    {

    }

    public void DecreaseFearLevel(float amount)
    {

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

    }

    public bool CheckIfAllMissionsCompleted()
    {
        for (int i = 0; i < npcs.Length; i++)
        {
            if(!npcs[i].gameObject.GetComponent<NPC>().isMissionComplete)
            {
                return false;
            }
        }
        return true;
    }

    public void MoveAllCharactersToRightSideOfHouse()
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
    }
}
