using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Possessed : MonoBehaviour
{
    public bool isPlayerPresent;
    public bool canHide;
    public GameObject glow;
    public int size;
    public GameObject hideableObject;
    bool hasPlayedSound;
    public AudioSource possessSfx;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) {
            if (canHide && hideableObject != null && !GameManager.instance.gamePaused && !GameManager.instance.gameEnded && GameManager.instance.isPossessing)
            {
                Hide();
            } else
            {
                Unpossess();
            }
        }

        if(isPlayerPresent)
        {
            PlayItemSoundOnce();
            ShowFullGlow();
        } else
        {
            ShowNoGlow();
        }
    }

    public void PlayItemSoundOnce()
    {
        if (!hasPlayedSound && possessSfx != null)
        {
            possessSfx.Play();
            hasPlayedSound = true;
        }
    }


    public void ShowSlightGlow()
    {
        Color glowColor = glow.GetComponent<SpriteRenderer>().color;
        glow.GetComponent<SpriteRenderer>().color = new Color(glowColor.r, glowColor.g, glowColor.b, 0.5f);
    }

    public void ShowFullGlow()
    {
        Color glowColor = glow.GetComponent<SpriteRenderer>().color;
        glow.GetComponent<SpriteRenderer>().color = new Color(glowColor.r, glowColor.g, glowColor.b, 1f);
    }

    public void ShowNoGlow()
    {
        Color glowColor = glow.GetComponent<SpriteRenderer>().color;
        glow.GetComponent<SpriteRenderer>().color = new Color(glowColor.r, glowColor.g, glowColor.b, 0f);
    }

    public void Hide()
    {
        GameManager.instance.isHiding = true;

        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;

        hideableObject.GetComponent<Hideable>().enabled = true;
        hideableObject.GetComponent<Hideable>().isOccupied = true;
        hideableObject.GetComponent<Hideable>().isGhost = false;
        hideableObject.gameObject.GetComponent<Hideable>().possessedObj = gameObject;

        canHide = false;

        GetComponent<PossessableMovement>().enabled = false;
        GetComponent<Possessed>().enabled = false;

        gameObject.SetActive(false);
    }

    public void Unpossess()
    {
        GameManager.instance.isPossessing = false;

        Player.instance.transform.position = transform.position;
        Player.instance.possesableObj = null;
        Player.instance.canPossess = false;
        Player.instance.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        Player.instance.GetComponent<SpriteRenderer>().enabled = false;
        Player.instance.gameObject.SetActive(true);
        Player.instance.GetComponent<Animator>().SetBool("outOfObject", true);

       CameraController.instance.target = Player.instance.transform;

        isPlayerPresent = false;

        GetComponent<Possessed>().enabled = false;
        GetComponent<PossessableMovement>().enabled = false;
    }

    public bool CollidingWithAHideableBiggerThanMe(Collider2D other)
    {
        if (other.gameObject.CompareTag("Hideable") || other.gameObject.CompareTag("Hideable"))
        {
            return other.gameObject.GetComponent<Hideable>().size >= size;
        }
        return false;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (CollidingWithAHideableBiggerThanMe(other))
        {
            canHide = true;
            hideableObject = other.gameObject;
        }
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (CollidingWithAHideableBiggerThanMe(other))
        {
            canHide = true;
            hideableObject = other.gameObject;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Hideable"))
        {
            canHide = false;
            hideableObject = null;
        }
        ShowNoGlow();
    }
}
