using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpeningMiddle : MonoBehaviour
{
    public GameObject doorToOpen;
    public GameObject doorToClose;
    private GameObject priest;
    private GameObject npc;

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("NPC") || other.gameObject.CompareTag("Priest"))
        {
            doorToClose.SetActive(false);
            doorToOpen.SetActive(true);
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("NPC"))
        {
            npc = null;
        }

        if(other.gameObject.CompareTag("Priest"))
        {
            priest = null;
        }

        if (priest == null && npc == null)
        {
            doorToClose.SetActive(true);
            doorToOpen.SetActive(false);
        }
        else
        {
            doorToOpen.SetActive(true);
            doorToClose.SetActive(false);
        }
    }
}
