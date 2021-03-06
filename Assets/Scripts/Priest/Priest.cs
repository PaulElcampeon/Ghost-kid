﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Priest : MonoBehaviour
{
    public Rigidbody2D rgb;

    public float walkSpeed;
    public bool isMovingRight;

    public float minXPosition;
    public float maxXPosition;
 
    public void MoveBetweenMaxAndMinPositions()
    {
         Vector2 newPosition;

        if (isMovingRight)
        {
            newPosition = Vector2.MoveTowards(rgb.position, new Vector2(maxXPosition, rgb.position.y), walkSpeed * Time.deltaTime);
            rgb.MovePosition(newPosition);

            if (newPosition.x == maxXPosition)
            {
                isMovingRight = false;
                Flip();
            }
        }
        else
        {
            newPosition = Vector2.MoveTowards(rgb.position, new Vector2(minXPosition, rgb.position.y), walkSpeed * Time.deltaTime);
            rgb.MovePosition(newPosition);

            if (newPosition.x == minXPosition)
            {
                isMovingRight = true;
                Flip();
            }
        }
    }

    public void Flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if (!GameManager.instance.isDead)
            {
                GameManager.instance.canMove = false;
                Player.instance.Die();
            }
        }
    }
}
