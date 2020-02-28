using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostDetector : MonoBehaviour
{
    public GameObject npc;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (!npc.GetComponent<NPC>().isWaitingInFear || !npc.GetComponent<NPC>().isRunningAway || !npc.GetComponent<NPC>().isTurning)
        {
            if (AreWeCollidingWithAMovingPossessable(other))
            {
                npc.GetComponent<Animator>().SetBool("isShocked", true);
            }
            else if (AreWeCollidingWithGhost(other))
            {
                npc.GetComponent<Animator>().SetBool("isShocked", true);
            }
        }
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (!npc.GetComponent<NPC>().isWaitingInFear || !npc.GetComponent<NPC>().isRunningAway || !npc.GetComponent<NPC>().isTurning)
        {
            if (AreWeCollidingWithAMovingPossessable(other))
            {
                npc.GetComponent<NPC>().isRunningAway = true;
                npc.GetComponent<Animator>().SetBool("isShocked", true);
            }
            else if (AreWeCollidingWithGhost(other))
            {
                npc.GetComponent<NPC>().isRunningAway = true;
                npc.GetComponent<Animator>().SetBool("isShocked", true);
            }
        }
    }

    public bool AreWeCollidingWithAMovingPossessable(Collider2D other)
    {
        if (other.gameObject.CompareTag("Possessable") && !npc.GetComponent<NPC>().isMissionComplete)
        {
            return other.gameObject.GetComponent<Possessed>().isPlayerPresent && other.gameObject.GetComponent<PossessableMovement>().isMoving;
        }
        return false;
    }

    public bool AreWeCollidingWithGhost(Collider2D other)
    {
        return other.gameObject.CompareTag("Player") && !other.gameObject.GetComponent<Player>().isDead && !npc.GetComponent<NPC>().isMissionComplete;
    }
}
