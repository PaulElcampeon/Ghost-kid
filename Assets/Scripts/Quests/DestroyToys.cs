using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyToys : MonoBehaviour
{
    public bool missionSuccess;
    public int numberOfToysToPutIn;
    private int counter = 0;

    public void OnTriggerEnter2D(Collider2D other)
    {
       if (other.gameObject.CompareTag("Possessable") && !missionSuccess && (other.gameObject.name == "TeddyBear" || other.gameObject.name == "Jet" || other.gameObject.name == "BasketBall"))
       {
            Destroy(other.gameObject);


            GameManager.instance.isPossessing = false;

            Player.instance.transform.position = transform.position;
            Player.instance.possesableObj = null;
            Player.instance.canPossess = false;
            Player.instance.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            Player.instance.gameObject.SetActive(true);

            CameraController.instance.target = Player.instance.transform;

            //when an object is destroyed the counter goes up by one.
            counter++;
            if (counter == numberOfToysToPutIn)
            {
                missionSuccess = true;
            }
       }
    }
}
