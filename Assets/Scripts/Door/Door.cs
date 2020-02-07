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
            //doorToClose.SetActive(false);
            //doorToOpen.SetActive(true);
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

            //doorToClose.SetActive(true);
            //doorToOpen.SetActive(false);
        }
        else
        {
            //GetComponent<Animator>().SetBool("isClosing", true);

            //doorToOpen.SetActive(true);
            //doorToClose.SetActive(false);
        }
    }
}
