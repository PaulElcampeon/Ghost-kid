using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitDetector : MonoBehaviour
{

    /*public void OnTriggerEnter2D(Collider2D other)
    {
        if (AreWeOnAWaitingPosition(other) && !HaveWeJustWaited())
        {
            GetComponent<Animator>().SetBool("isWaiting", true);
            GetComponent<NPC>().justWaited = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("WaitingPosition"))
        {
            GetComponent<NPC>().justWaited = false;
        }
    }

    public bool AreWeOnAWaitingPosition(Collider2D other)
    {
        return other.gameObject.CompareTag("WaitingPosition");
    }

    public bool HaveWeJustWaited()
    {
        return GetComponent<NPC>().justWaited;
    }*/
}
