using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpeningRight : MonoBehaviour
{
    public GameObject doorToOpen;
    public GameObject doorToClose;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("NPC"))
        {
            if (!other.gameObject.GetComponent<NPC>().isMovingRight)
            {
                doorToClose.SetActive(false);
                doorToOpen.SetActive(true);
            }

            if (other.gameObject.GetComponent<NPC>().isMovingRight)
            {
                doorToClose.SetActive(true);
                doorToOpen.SetActive(false);
            }

            Debug.Log(other.gameObject.GetComponent<NPC>().isMovingRight);
        }
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("NPC"))
        {
            if (!other.gameObject.GetComponent<NPC>().isMovingRight)
            {
                doorToClose.SetActive(false);
                doorToOpen.SetActive(true);
            }

            if (other.gameObject.GetComponent<NPC>().isMovingRight)
            {
                doorToClose.SetActive(true);
                doorToOpen.SetActive(false);
            }

            Debug.Log(other.gameObject.GetComponent<NPC>().isMovingRight);
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
       /* if (other.gameObject.CompareTag("NPC"))
        {
            if (other.gameObject.GetComponent<NPC>().isMovingRight)
                doorToClose.SetActive(true);
                doorToOpen.SetActive(false);
        }*/
    }
}
