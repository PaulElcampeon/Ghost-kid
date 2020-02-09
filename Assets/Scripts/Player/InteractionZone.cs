using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionZone : MonoBehaviour
{
    public GameObject interactionObject;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Possessable") || other.gameObject.CompareTag("toys"))
        {
            Player.instance.canPossess = true;
            Player.instance.possesableObj = other.gameObject;

            other.gameObject.GetComponent<Possessed>().ShowSlightGlow();
        }

        if (other.gameObject.CompareTag("Hideable"))
        {
            Player.instance.canHide = true;
            Player.instance.hideableObj = other.gameObject;
            other.gameObject.GetComponent<Hideable>().hideableSignifier.SetActive(true);
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Possessable") && !GameManager.instance.isPossessing && !GameManager.instance.isHiding)
        {
            Player.instance.canPossess = false;
            Player.instance.possesableObj = null;

            other.gameObject.GetComponent<Possessed>().ShowNoGlow();

            if (other.gameObject.GetComponent<Possessed>().isBoomBox())
            {
                other.gameObject.GetComponent<Possessed>().DisableBoomBox();
            }
        }

        if (other.gameObject.CompareTag("Hideable"))
        {
            Player.instance.canHide = false;
            Player.instance.hideableObj = null;
            other.gameObject.GetComponent<Hideable>().hideableSignifier.SetActive(false);
        }
    }
}
