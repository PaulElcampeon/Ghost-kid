using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDrawer : MonoBehaviour
{
    public bool missionSuccess = false;
    public AudioSource sfx;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("cupboard"))
        {
            sfx.Play();
            Destroy(other.gameObject);
            missionSuccess = true;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
         if (other.gameObject.CompareTag("cupboard"))
                {
                    Destroy(other.gameObject);
                }
    }
}


