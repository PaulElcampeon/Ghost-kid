using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool canPossess;
    public GameObject possesableObj;
    public Animator animator;
    public Vector3 playerStartingPoint;

    public static Player instance;
  
    void Start()
    {
        instance = this;
        transform.position = playerStartingPoint;
        GetComponent<Animator>().SetBool("outOfObject", true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !GameManager.instance.gameEnded && !GameManager.instance.gamePaused && !GameManager.instance.isPossessing)
        {
            if (canPossess && possesableObj != null)
            {
                GameManager.instance.isPossessing = true;

                GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
                GetComponent<Animator>().SetBool("isPossessed", true);
            }
        }
    }

    public void Possess()
    {
        possesableObj.GetComponent<PossessableMovement>().enabled = true;
        //possesableObj.GetComponent<Possessed>().enabled = true;
        //possesableObj.GetComponent<Possessed>().isPlayerPresent = true;

        CameraController.instance.target = possesableObj.GetComponent<Rigidbody2D>().transform;

        /*
        We could disbale the player and playerMovement script but they will get disabled when we the gameObject active to false
         * */
        canPossess = false;
        possesableObj.GetComponent<Possessed>().Possess();
        gameObject.SetActive(false);

    }
}
