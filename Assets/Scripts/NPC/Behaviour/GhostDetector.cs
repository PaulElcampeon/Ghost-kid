﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostDetector : MonoBehaviour
{
    public GameObject npc;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (AreWeCollidingWithAMovingPossessable(other))
        {
       
            npc.GetComponent<Animator>().SetBool("isWaiting", false);
            npc.GetComponent<Animator>().SetBool("isWaitingInFear", false);
            npc.GetComponent<Animator>().SetBool("checkOutSound", false);
            npc.GetComponent<Animator>().SetBool("isWalking", false);
            npc.GetComponent<Animator>().SetBool("isShocked", true);
        }

        if (AreWeCollidingWithGhost(other))
        {
            npc.GetComponent<Animator>().SetBool("isWaiting", false);
            npc.GetComponent<Animator>().SetBool("isWaitingInFear", false);
            npc.GetComponent<Animator>().SetBool("checkOutSound", false);
            npc.GetComponent<Animator>().SetBool("isWalking", false);
            npc.GetComponent<Animator>().SetBool("isShocked", true);
        }
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (AreWeCollidingWithAMovingPossessable(other))
        {
            //Check if we are inspecting a sound and if so cancel it
            if (npc.GetComponent<NPC>().isInspectingSound)
            {
                npc.GetComponent<NPC>().CancelInspectingSound();
            }

            npc.GetComponent<NPC>().isRunningAway = true;
            npc.GetComponent<Animator>().SetBool("isWaiting", false);
            npc.GetComponent<Animator>().SetBool("isWaitingInFear", false);
            npc.GetComponent<Animator>().SetBool("checkOutSound", false);
            npc.GetComponent<Animator>().SetBool("isWalking", false);
            npc.GetComponent<Animator>().SetBool("isShocked", true);
        }

        if (AreWeCollidingWithGhost(other))
        {
            if (npc.GetComponent<NPC>().isInspectingSound)
            {
                npc.GetComponent<NPC>().CancelInspectingSound();
            }

            npc.GetComponent<NPC>().isRunningAway = true;
            npc.GetComponent<Animator>().SetBool("isWaiting", false);
            npc.GetComponent<Animator>().SetBool("isWaitingInFear", false);
            npc.GetComponent<Animator>().SetBool("checkOutSound", false);
            npc.GetComponent<Animator>().SetBool("isWalking", false);
            npc.GetComponent<Animator>().SetBool("isShocked", true);
        }
    }

    public bool AreWeCollidingWithAMovingPossessable(Collider2D other)
    {
        if (other.gameObject.CompareTag("Possessable"))
        {
            return other.gameObject.GetComponent<Possessed>().isPlayerPresent && other.gameObject.GetComponent<PossessableMovement>().isMoving;
        }

        return false;
    }

    public bool AreWeCollidingWithGhost(Collider2D other)
    {
        return other.gameObject.CompareTag("Player");
    }
}
