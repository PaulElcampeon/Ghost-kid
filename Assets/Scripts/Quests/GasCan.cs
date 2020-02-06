using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasCan : MonoBehaviour
{

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "LawnMower")
        {
            if (!other.gameObject.GetComponent<Possessed>().isPlayerPresent)
            {
                other.gameObject.GetComponent<LawnmowerMission>().isGassed = true;

                Destroy(this.gameObject);

                GameManager.instance.isPossessing = false;

                Player.instance.transform.position = transform.position;
                Player.instance.possesableObj = null;
                Player.instance.canPossess = false;
                Player.instance.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                Player.instance.gameObject.SetActive(true);

                CameraController.instance.target = Player.instance.transform;
            }
        }
        
    }
}
