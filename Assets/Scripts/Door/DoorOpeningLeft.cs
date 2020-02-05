using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpeningLeft : MonoBehaviour
{
    public GameObject doorToOpen;
    public GameObject doorToClose;

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("NPC") || other.gameObject.CompareTag("Priest"))
        {
            if (!other.gameObject.GetComponent<NPC>().isMovingRight)
            {
                doorToClose.SetActive(true);
                doorToOpen.SetActive(false);
            }

            if (other.gameObject.GetComponent<NPC>().isMovingRight)
            {
                doorToClose.SetActive(false);
                doorToOpen.SetActive(true);
            }
        }
    }
}
