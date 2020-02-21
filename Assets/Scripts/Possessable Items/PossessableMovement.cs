using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PossessableMovement : MonoBehaviour
{
    public float speed;
    private Vector3 bottomLeftLimit;
    private Vector3 topRightLimit;
    public bool isMovingRight;
    public bool isMovingUp;
    public bool isMoving;

    void FixedUpdate()
    {
        if (GameManager.instance.canMove && !GameManager.instance.gamePaused && !GameManager.instance.isHiding && !GameManager.instance.gameEnded)
        {
            if (Input.GetAxisRaw("Horizontal") == 1)
            {
                MoveRight();
            }

            if (Input.GetAxisRaw("Horizontal") == -1)
            {
                MoveLeft();
            }

            if (Input.GetAxisRaw("Vertical") == 1)
            {
                MoveUp();
            }

            if (Input.GetAxisRaw("Vertical") == -1)
            {
                MoveDown();
            }

            //This block of code differntiates this class from the playerMovement class, we need to know if a possesable item is moving so the npc can react to it
            if(Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0) {
                isMoving = true;
            } else
            {
                isMoving = false;
            }
        }
    }

    public void MoveRight()
    {
        GetComponent<Rigidbody2D>().transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
        Player.instance.GetComponent<Rigidbody2D>().transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
        isMovingRight = true;
        Flip();
    }

    public void MoveLeft()
    {
        GetComponent<Rigidbody2D>().transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
        Player.instance.GetComponent<Rigidbody2D>().transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
        isMovingRight = false;
        Flip();

    }

    public void MoveUp()
    {
        GetComponent<Rigidbody2D>().transform.position = new Vector3(transform.position.x, transform.position.y + +speed * Time.deltaTime, transform.position.z);
        Player.instance.GetComponent<Rigidbody2D>().transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
        isMovingUp = true;
    }

    public void MoveDown()
    {
        isMovingUp = false;
        Player.instance.GetComponent<Rigidbody2D>().transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
        GetComponent<Rigidbody2D>().transform.position = new Vector3(transform.position.x, transform.position.y - speed * Time.deltaTime, transform.position.z);
    }

    public void SetBounds(Vector3 bottomLeftLimit, Vector3 topRightLimit)
    {
        this.bottomLeftLimit = bottomLeftLimit + new Vector3(1f, 1f, 0f);
        this.topRightLimit = topRightLimit + new Vector3(-1f, -1f, 0f);
    }

    public void Flip()
    {
        if (isMovingRight)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }
}
