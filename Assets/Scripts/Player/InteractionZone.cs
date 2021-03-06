﻿using System.Collections;
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
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Possessable") && !GameManager.instance.isPossessing && !GameManager.instance.isHiding)
        {
            Player.instance.canPossess = false;
            Player.instance.possesableObj = null;

            other.gameObject.GetComponent<Possessed>().ShowNoGlow();
        }
    }
}
