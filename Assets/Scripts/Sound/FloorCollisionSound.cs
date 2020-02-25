using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorCollisionSound : MonoBehaviour
{

    public void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Possessable") || other.gameObject.CompareTag("toys"))
        {
            if (!other.gameObject.GetComponent<Item>().isOnFloor)
            {
                other.gameObject.GetComponent<Item>().isOnFloor = true;
                SoundEngine.instance.PlayItemDropSound();
            }
        }
        
    }


    public void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Possessable") || other.gameObject.CompareTag("toys"))
        {
            other.gameObject.GetComponent<Item>().isOnFloor = false;
        }
    }
}
