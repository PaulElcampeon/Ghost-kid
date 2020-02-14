using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public Rigidbody2D rgb;

    public float runSpeed;
    public float walkSpeed;
    public float waitFor;

    public bool isRunningAway;
    public bool isWaiting;
    public bool isWaitingInFear;
    public bool isMissionComplete;
    public bool isTurning;
    public float missionCompleteAreaXPosition;

    public AudioSource scream;

    //This should always start off as false since we have our sprites already moving towards the left by default
    public bool isMovingRight;
    public bool startedAllMissionsCompleteAnimation = false;

    public float minXPosition;
    public float maxXPosition;

    public MissionCompleteZone missionCompleteZone;

    public GameObject heartParticles;

    void Start()
    {
        isMovingRight = false;
    }

    public void LateUpdate()
    {
       if(GameManager.instance.allMissionsComplete && GetComponent<Rigidbody2D>().transform.position.x != missionCompleteAreaXPosition && !startedAllMissionsCompleteAnimation) 
        {
            startedAllMissionsCompleteAnimation = true;
            GetComponent<Animator>().SetBool("allMissionsCompleted", true);
        }
    }

    public void RestartWalkCycleFromWaitingInFearPosition()
    {
        if(rgb.position.x == minXPosition)
        {
            isMovingRight = true;
        } else
        {
            isMovingRight = false;
        }
    }
  
    public void MoveBetweenMaxAndMinPositions()
    {
        if (isMovingRight)
        {
            MoveRight();
        } else
        {
            MoveLeft();
        }
    }

    public void Flip()
    {
        if (!isRunningAway)
        {
            DisplacementCorrectionWhenTurning();
        }
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public void MoveToPosition(Vector3 targetPosition)
    {
        Vector2 newPosition = Vector2.MoveTowards(rgb.position, new Vector2(targetPosition.x, rgb.position.y), runSpeed * Time.deltaTime);

        rgb.MovePosition(newPosition);
    }

    public void MoveToPositionWalking(Vector3 targetPosition)
    {
        Vector2 newPosition = Vector2.MoveTowards(rgb.position, new Vector2(targetPosition.x, rgb.position.y), walkSpeed * Time.deltaTime);

        rgb.MovePosition(newPosition);
    }

    public void PlayScreamAudio()
    {
        SoundEngine.instance.PlaySFX(scream);
    }

    public void DisplacementCorrectionWhenTurning()
    {
        if (isMovingRight)
        {
            rgb.transform.position += new Vector3(1f, 0f, 0f);
        }
        else
        {
            rgb.transform.position += new Vector3(-1f, 0f, 0f);
        }
    }

    public void RunAwayFromPlayer()
    {
        if (rgb.position.x < Player.instance.transform.position.x)
        {
            RunLeft();
        }
        else
        {
            RunRight();
        }
    }

    public void RunLeft()
    {
        //This means we must be movingRight since our ghost detect is positioned in the direct we are moving
        if (isMovingRight)
        {
            Flip();
            isMovingRight = false;
        }

        //Run west
        Vector2 newPosition = Vector2.MoveTowards(rgb.position, new Vector2(minXPosition, rgb.position.y), runSpeed * Time.deltaTime);
        rgb.MovePosition(newPosition);

        if (rgb.position.x == minXPosition)
        {
            GetComponent<Animator>().SetBool("isShocked", false);
            GetComponent<Animator>().SetBool("isWaiting", false);
            isRunningAway = false;
            GetComponent<Animator>().SetBool("isRunning", false);
            isWaitingInFear = true;
            GetComponent<Animator>().SetBool("isWaitingInFear", true);
        }
    }

    public void RunRight()
    {
        //This means we must be movingLeft since our ghost detect is positioned in the direct we are moving
        if (!isMovingRight)
        {
            Flip();
            isMovingRight = true;
        }

        //Run east
        Vector2 newPosition = Vector2.MoveTowards(rgb.position, new Vector3(maxXPosition, rgb.position.y), runSpeed * Time.deltaTime);
        rgb.MovePosition(newPosition);

        if (rgb.position.x == maxXPosition)
        {
            GetComponent<Animator>().SetBool("isShocked", false);
            GetComponent<Animator>().SetBool("isWaiting", false);
            isRunningAway = false;
            GetComponent<Animator>().SetBool("isRunning", false);
            isWaitingInFear = true;
            GetComponent<Animator>().SetBool("isWaitingInFear", true);
        }
    }

    public void MoveRight()
    {
        Vector2 newPosition = Vector2.MoveTowards(rgb.position, new Vector2(maxXPosition, rgb.position.y), walkSpeed * Time.deltaTime);
        rgb.MovePosition(newPosition);

        if (newPosition.x == maxXPosition)
        {
            GetComponent<Animator>().SetTrigger("turn");
        }
    }

    public void MoveLeft()
    {
        Vector2 newPosition = Vector2.MoveTowards(rgb.position, new Vector2(minXPosition, rgb.position.y), walkSpeed * Time.deltaTime);
        rgb.MovePosition(newPosition);

        if (newPosition.x == minXPosition)
        {
            GetComponent<Animator>().SetTrigger("turn");
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("WaitingPosition") && !isRunningAway)
        {
            GetComponent<Animator>().SetBool("isWalking", false);
            isWaiting = true;
            GetComponent<Animator>().SetBool("isWaiting", true);
        }
    }
}
