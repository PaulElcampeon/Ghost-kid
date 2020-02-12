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
    public bool isInspectingSound;
    public bool isWaiting;
    public bool isWaitingInFear;
    public bool isMissionComplete;
    public float missionCompleteAreaXPosition;

    public AudioSource scream;

    //This should always start off as false since we have our sprites already moving towards the left by default
    public bool isMovingRight;
    public bool startedAllMissionsCompleteAnimation = false;

    public float minXPosition;
    public float maxXPosition;

    public GameObject heartParticles;

    public GameObject itemThatJustMadeASound;

    void Start()
    {
        isMovingRight = false;
    }

    public void Update()
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
            Flip();
            isMovingRight = true;
        } else
        {
            Flip();
            isMovingRight = false;
        }
    }
  
    public void MoveBetweenMaxAndMinPositions()
    {
        if (isMovingRight)
        {
            Vector2 newPosition = Vector2.MoveTowards(rgb.position, new Vector2(maxXPosition, rgb.position.y), walkSpeed * Time.deltaTime);
            rgb.MovePosition(newPosition);

            if (newPosition.x == maxXPosition)
            {
                isMovingRight = false;
                Flip();
            }
        } else
        {
            Vector2 newPosition = Vector2.MoveTowards(rgb.position, new Vector2(minXPosition, rgb.position.y), walkSpeed * Time.deltaTime);
            rgb.MovePosition(newPosition);

            if (newPosition.x == minXPosition)
            {
                isMovingRight = true;
                Flip();
            }
        }
    }

    public void Flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public void RunAwayFromPlayer()
    {
        if (rgb.position.x < Player.instance.transform.position.x)
        {
            //This means we must be movingRight since our ghost detect is positioned in the direct we are moving
            if(isMovingRight)
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
        } else
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

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("WaitingPosition") && !isRunningAway &&!isInspectingSound)
        {
            GetComponent<Animator>().SetBool("isWalking", false);
            isWaiting = true;
            GetComponent<Animator>().SetBool("isWaiting", true);
        }
    }

    public void PlayScreamAudio()
    {
        SoundEngine.instance.PlaySFX(scream);
    }
}
