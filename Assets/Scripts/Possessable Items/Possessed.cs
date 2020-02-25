using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Possessed : MonoBehaviour
{
    public bool isPlayerPresent;
    public bool canHide;
    public GameObject glow;
    public bool hasPlayedSound;
    public AudioSource possessSfx;
    
    public virtual void Update()
    {
        if (InputManager.ActionButton()) {
            Unpossess();
        }

        if(isPlayerPresent)
        {
            //PlayItemSoundOnce();
            ShowFullGlow();
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

    public void Unpossess()
    {
        if (isPlayerPresent)
        {
            GameManager.instance.isPossessing = false;

            Player.instance.transform.position = transform.position;
            Player.instance.possesableObj = null;
            Player.instance.canPossess = false;
            Player.instance.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            Player.instance.GetComponent<SpriteRenderer>().enabled = false;
            Player.instance.gameObject.SetActive(true);
            Player.instance.Unpossess();

            CameraController.instance.target = Player.instance.transform;

            isPlayerPresent = false;

            GetComponent<PossessableMovement>().enabled = false;
        }
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Priest" && GameManager.instance.isPossessing && isPlayerPresent)
        {
            Unpossess();
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            ShowNoGlow();
        }
    }

    public void Possess()
    {
        isPlayerPresent = true;
    }
}
