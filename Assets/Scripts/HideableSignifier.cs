using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideableSignifier : MonoBehaviour
{
    public GameObject closed;
    public GameObject open;
    public bool isAlreadyOpen;

    public void Hide()
    {
        open.SetActive(false);
        closed.SetActive(true);
        isAlreadyOpen = false;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (!isAlreadyOpen)
        {
            if (other.gameObject.CompareTag("PlayerInteraction") || (other.gameObject.CompareTag("Possessable") && other.gameObject.GetComponent<Possessed>().isPlayerPresent))
            {
                closed.SetActive(false);
                open.SetActive(true);
                open.transform.GetChild(0).gameObject.SetActive(true);

                isAlreadyOpen = true;
            }
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("PlayerInteraction") || (other.gameObject.CompareTag("Possessable") && other.gameObject.GetComponent<Possessed>().isPlayerPresent))
        {
            open.SetActive(false);
            open.transform.GetChild(0).gameObject.SetActive(false);
            closed.SetActive(true);
            isAlreadyOpen = false;
        }
        
    }
}
