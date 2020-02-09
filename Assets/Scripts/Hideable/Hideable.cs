using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hideable : MonoBehaviour
{
    public int size;
    public bool isOccupied;
    public GameObject possessedObj;
    public bool isGhost;
    public GameObject hideableSignifier;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isOccupied)
            {
                Show();
            }
        }
    }

    public void Show()
    {
        GameManager.instance.isHiding = false;

        if (isGhost)
        {
            Player.instance.GetComponent<Rigidbody2D>().transform.position = GetComponent<Rigidbody2D>().transform.position;
            Player.instance.hideableObj = null;
            Player.instance.canHide = false;
            Player.instance.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            Player.instance.GetComponent<SpriteRenderer>().enabled = false;
            Player.instance.gameObject.SetActive(true);
            Player.instance.GetComponent<Animator>().SetBool("outOfObject", true);

            CameraController.instance.target = Player.instance.transform;

            GetComponent<Hideable>().enabled = false;
            isOccupied = false;
            possessedObj = null;

        } else
        {
            GameManager.instance.isPossessing = true;

            possessedObj.transform.position = transform.position;
            possessedObj.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            possessedObj.SetActive(true);
            possessedObj.GetComponent<PossessableMovement>().enabled = true;
            possessedObj.GetComponent<Possessed>().enabled = true;
            possessedObj.GetComponent<Possessed>().canHide = true;

            GetComponent<Hideable>().enabled = false;
            isOccupied = false;
            possessedObj = null;
        }
    }
}
