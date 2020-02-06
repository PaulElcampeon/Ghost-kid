using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGarderDoor : MonoBehaviour
{

    public GameObject openedDoor;
    public GameObject closeDoor;

    public void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("NPC") && GameManager.instance.allMissionsComplete)
        {
            closeDoor.SetActive(false);
            openedDoor.SetActive(true);
        }
        
    }
}
