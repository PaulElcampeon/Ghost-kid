using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundDetector : MonoBehaviour
{
    public GameObject npc;

    public bool AreWeHearingAnItemMoveAbout(Collider2D other)
    {
        if (other.gameObject.CompareTag("Possessable") && !npc.GetComponent<NPC>().isMissionComplete)
        {
            return other.gameObject.GetComponent<Possessed>().isPlayerPresent && other.gameObject.GetComponent<PossessableMovement>().isMoving;
        }

        return false;
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (AreWeHearingAnItemMoveAbout(other))
        {
            if (!npc.GetComponent<NPC>().isRunningAway && !npc.GetComponent<NPC>().isWaitingInFear)
            {
                npc.GetComponent<NPC>().isInspectingSound = true;
                npc.GetComponent<NPC>().isWaiting = false;
                npc.GetComponent<NPC>().itemThatJustMadeASound = other.gameObject;
                npc.GetComponent<Animator>().SetBool("isWaiting", false);
                npc.GetComponent<Animator>().SetBool("isWalking", false);
                npc.GetComponent<Animator>().SetBool("checkOutSound", true);
            }
        }
    }
}
