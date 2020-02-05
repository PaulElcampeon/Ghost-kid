using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeMusic : MonoBehaviour
{
   public AudioSource sound;

   void Start()
   {
      sound = GetComponent<AudioSource>();
   }
   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.gameObject.CompareTag("Music"))
      {
         sound.Play ();
         
      }
   }
}
