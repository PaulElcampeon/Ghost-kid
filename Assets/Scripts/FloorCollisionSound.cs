using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorCollisionSound : MonoBehaviour
{

    public void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Possessable") || other.gameObject.CompareTag("toys"))
        {
            SoundEngine.instance.PlayItemDropSound();
        }
        
    }
}
