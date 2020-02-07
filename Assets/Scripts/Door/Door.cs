using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private GameObject priest;
    private GameObject npc;
    public GameObject door;
   
    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("NPC") || other.gameObject.CompareTag("Priest"))
        {
            door.GetComponent<Animator>().SetBool("isClosing", false);
            door.GetComponent<Animator>().SetBool("isOpening", true);
            door.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("NPC"))
        {
            npc = null;
        }

        if (other.gameObject.CompareTag("Priest"))
        {
            priest = null;
        }

        if (priest == null && npc == null)
        {
            door.GetComponent<Animator>().SetBool("isOpening", false);
            door.GetComponent<Animator>().SetBool("isClosing", true);
            door.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}
