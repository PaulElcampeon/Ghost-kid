using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool canPossess;
    public bool canHide;
    public GameObject possesableObj;
    public GameObject hideableObj;
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
            } else if (canHide && hideableObj != null)
            {
                GameManager.instance.isHiding = true;

                GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
                GetComponent<Animator>().SetBool("isHidding", true);
            }
        }
    }

    public void Possess()
    {
        possesableObj.GetComponent<PossessableMovement>().enabled = true;
        possesableObj.GetComponent<Possessed>().enabled = true;
        possesableObj.GetComponent<Possessed>().isPlayerPresent = true;

        CameraController.instance.target = possesableObj.GetComponent<Rigidbody2D>().transform;

        /*
        We could disbale the player and playerMovement script but they will get disabled when we the gameObject active to false
         * */
        canPossess = false;
        gameObject.SetActive(false);
    }

    public void Hide()
    {
        hideableObj.GetComponent<Hideable>().enabled = true;
        hideableObj.GetComponent<Hideable>().isOccupied = true;
        hideableObj.GetComponent<Hideable>().isGhost = true;
        hideableObj.gameObject.GetComponent<Hideable>().possessedObj = gameObject;

        CameraController.instance.target = hideableObj.GetComponent<Rigidbody2D>().transform;

        /*
        We could disbale the player and playerMovement script but they will get disabled when we the gameObject active to false
         * */
        canHide = false;
        gameObject.SetActive(false);
    }
}
