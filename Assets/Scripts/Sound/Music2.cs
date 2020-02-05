using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Music2 : MonoBehaviour
{

    public AudioSource collisionSound;
    public AudioClip lullaby;
    

    void Start()
    {
        collisionSound = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Music")
        {
            collisionSound.PlayOneShot(lullaby);
        }
    }
}
